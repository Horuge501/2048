using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int width = 4;
    [SerializeField] private int height = 4;
    [SerializeField] private Node nodePrefab;
    [SerializeField] private Block blockPrefab;
    [SerializeField] private SpriteRenderer boardPrefab;

    private List<Node> nodes;
    private List<Block> blocks;

    void Start() 
    {
        GenerataField();
    }

    void Update() {
        
    }

    void GenerataField() 
    {
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
    }

    void SpawnBlocks(int amount) 
    {
        for (int i = 0; i < amount; i++) 
        {
            Block block = Instantiate(blockPrefab);
        }
    }
}
