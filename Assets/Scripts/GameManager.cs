using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int width = 4;
    [SerializeField] private int height = 4;
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Block blockPrefab;
    [SerializeField] private SpriteRenderer boardPrefab;
    [SerializeField] private List<BlockType> types;
    [SerializeField] private float travelTime = 0.2f;
    [SerializeField] private int winCondition = 2048;

    [SerializeField] private GameObject winScreen, loseScreen;

    private InputAction moveLeftAction;
    private InputAction moveRightAction;
    private InputAction moveUpAction;
    private InputAction moveDownAction;

    private List<Node> nodes;
    private List<Block> blocks;
    private GameState state;
    private int round;

    private BlockType GetBlockTypeByValue(int value) => types.First(t => t.Value == value);

    void Start() 
    {
        var inputActions = new PlayerInputs();
        moveLeftAction = inputActions.Direction.Left;
        moveRightAction = inputActions.Direction.Right;
        moveUpAction = inputActions.Direction.Up;
        moveDownAction = inputActions.Direction.Down;

        moveLeftAction.started += ctx => Shift(Vector2.left);
        moveRightAction.started += ctx => Shift(Vector2.right);
        moveUpAction.started += ctx => Shift(Vector2.up);
        moveDownAction.started += ctx => Shift(Vector2.down);
        inputActions.Enable();

        ChangeState(GameState.GenerateLevel);
    }

    void Update()
    {
        if (state != GameState.WaitingInput) return;
    }

    private void ChangeState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.GenerateLevel:
                GenerateField();
                break;
            case GameState.SpawningBlock:
                SpawnBlocks(round++ == 0 ? 2 : 1);
                break;
            case GameState.WaitingInput:
                break;
            case GameState.Moving:
                break;
            case GameState.Win:
                winScreen.SetActive(true);
                Invoke("ReloadScene", 5f);
                break;
            case GameState.Lose:
                loseScreen.SetActive(true);
                Invoke("ReloadScene", 5f);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }



    void GenerateField() 
    {
        round = 0;
        nodes = new List<Node>();
        blocks = new List<Block>();
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++) 
            {
                Node node = Instantiate(nodePrefab, new Vector2(x, y), Quaternion.identity);
                nodes.Add(node);
            }
        }

        Vector2 center = new Vector2((float)width / 2 - 0.5f, (float)height / 2 - 0.5f);

        SpriteRenderer board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(width, height);

        Camera.main.transform.position = new Vector3(center.x, center.y, -10);

        ChangeState(GameState.SpawningBlock);
    }

    void SpawnBlocks(int amount) 
    {
        var freeNodes = nodes.Where(n => n.occupiedBlock == null).OrderBy(b => Random.value).ToList();

        foreach (Node node in freeNodes.Take(amount))
        {
            SpawnBlock(node, Random.value > 0.8f ? 4 : 2);
        }

        if (freeNodes.Count() == 1)
        {
            ChangeState(GameState.Lose);
            return;
        }

        ChangeState(blocks.Any(b => b.Value == winCondition) ? GameState.Win : GameState.WaitingInput);
    }

    void SpawnBlock(Node node, int value)
    {
        Block block = Instantiate(blockPrefab, node.Pos, Quaternion.identity);
        block.Init(GetBlockTypeByValue(value));
        block.SetBlock(node);
        blocks.Add(block);
    }


    void Shift(Vector2 dir)
    {
        ChangeState(GameState.Moving);

        var orderedBlocks = blocks.OrderBy(b => b.Pos.x).ThenBy(b => b.Pos.y).ToList();
        if (dir == Vector2.right || dir == Vector2.up) orderedBlocks.Reverse();

        foreach (Block block in orderedBlocks)
        {
            var next = block.Node;
            do
            {
                block.SetBlock(next);

                var possibleNode = GetNodeAtPosition(next.Pos + dir);
                if (possibleNode != null)
                {
                    if (possibleNode.occupiedBlock != null && possibleNode.occupiedBlock.CanMerge(block.Value))
                    {
                        block.MergeBlock(possibleNode.occupiedBlock);
                    }
                    else if (possibleNode.occupiedBlock == null) next = possibleNode;

                }


            } while (next != block.Node);

            block.transform.DOMove(block.Node.Pos, travelTime);
        }

        var sequence = DOTween.Sequence();

        foreach (var block in orderedBlocks)
        {
            var movePoint = block.MergingBlock != null ? block.MergingBlock.Node.Pos : block.Node.Pos;

            sequence.Insert(0, block.transform.DOMove(movePoint, travelTime).SetEase(Ease.InQuad));
        }

        sequence.OnComplete(() => {
            var mergeBlocks = orderedBlocks.Where(b => b.MergingBlock != null).ToList();
            foreach (var block in mergeBlocks)
            {
                MergeBlocks(block.MergingBlock, block);
            }
                ChangeState(GameState.SpawningBlock);
        });
    }

    void MergeBlocks(Block baseBlock, Block mergingBlock)
    {
        var newValue = baseBlock.Value * 2;

        SpawnBlock(baseBlock.Node, newValue);

        RemoveBlock(baseBlock);
        RemoveBlock(mergingBlock);
    }

    void RemoveBlock(Block block)
    {
        blocks.Remove(block);
        Destroy(block.gameObject);
    }

    Node GetNodeAtPosition(Vector2 pos)
    {
        return nodes.FirstOrDefault(n => n.Pos == pos);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("2048");
    }
}

[Serializable]

public struct BlockType
{
    public int Value;
    public Color Color;
}

public enum GameState
{
    GenerateLevel,
    SpawningBlock,
    WaitingInput,
    Moving,
    Win,
    Lose
}