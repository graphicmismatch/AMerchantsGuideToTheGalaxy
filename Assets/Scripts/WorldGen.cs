using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldGen : MonoBehaviour
{
    public Tilemap ground;
    public Tilemap decorations;
    public Tile[] tiles;
    int x = 0, y = 0;
    public Vector2Int minmax;
    public GameObject shop;
    public GameObject fuelshop;
    private List<Vector2Int> trees;

    public List<Item> planetItems = new List<Item>() {};
    // Start is called before the first frame update
    void Start()
    {
        GetItems();
        trees = new List<Vector2Int>();
        setSeed(Data.getSeed(), Data.getPlanet());
        spawnGround();
        spawnDecorations();
        spawnBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetItems()
    {
        Inventory inv = FindObjectOfType<Inventory>();
        List<Item> tmp = new List<Item>();
        tmp.AddRange(inv.items);
        for (int i = 0; i< 4; i++)
        {
            Item tmpitem = tmp[Random.Range(0, tmp.Count)];
            planetItems.Add(tmpitem);
            tmp.Remove(tmpitem);
        }
    }
    void spawnGround()
    {
        Color color = Color.HSVToRGB(Random.Range(0f, 1f), 0.27f, 0.93f);
        ground.color = color;
        x = Random.Range(minmax.x, minmax.y);
        y = Random.Range(minmax.x, minmax.y);
        for(int i = -20;i<= x+20;i++)
        {
            for (int j = -20; j <= y + 20; j++)
            {
                ground.SetTile(new Vector3Int(i, j, 0), tiles[0]);
            }
        }
    }
    void spawnDecorations()
    {
        int number = Random.Range(x, x + 10);
        for (int i = 0; i <= number; i++)
        {
            int tx = Random.Range(0, x);
            int ty = Random.Range(0, y);
            decorations.SetTile(new Vector3Int(tx, ty, 0), tiles[1]);
            trees.Add(new Vector2Int(tx, ty));
        }

        for (int i = -20; i <= x + 3; i++)
        {
            for (int j = -20; j <= -2; j++)
            {
                decorations.SetTile(new Vector3Int(i, j, 0), tiles[1]);
            }
        }
        for (int i = -20; i <= x + 3; i++)
        {
            for (int j = y; j <= y+20; j++)
            {
                decorations.SetTile(new Vector3Int(i, j, 0), tiles[1]);
            }
        }
        for (int i = -20; i <=  -3; i++)
        {
            for (int j = -20; j <= y+20; j++)
            {
                decorations.SetTile(new Vector3Int(i, j, 0), tiles[1]);
            }
        }
        for (int i = x; i <= x + 20; i++)
        {
            for (int j = -20; j <= y+20; j++)
            {
                decorations.SetTile(new Vector3Int(i, j, 0), tiles[1]);
            }
        }
    }
    void spawnBuildings()
    {
        int number = Random.Range(4, 9);
        for (int i = 0; i <= number; i++)
        {
            float tx = Random.Range(0f, x);
            float ty = Random.Range(0f, y);
            Instantiate(shop, new Vector2(tx, ty), Quaternion.identity).GetComponent<Shop>().SetVal(planetItems);
            foreach (Vector2Int pos in trees)
            {
                if (Vector2.Distance(new Vector2(tx, ty), (Vector2)pos) <= 5)
                {
                    decorations.SetTile((Vector3Int)pos, null);
                }
            }
        }

        number = Random.Range(4, 9);
        for (int i = 0; i <= number; i++)
        {
            float tx = Random.Range(0f, x);
            float ty = Random.Range(0f, y);
            Instantiate(fuelshop, new Vector2(tx, ty), Quaternion.identity);
            foreach (Vector2Int pos in trees)
            {
                if (Vector2.Distance(new Vector2(tx, ty), (Vector2)pos) <= 5)
                {
                    decorations.SetTile((Vector3Int)pos, null);
                }
            }
        }



    }
    public void setSeed(int s, int o = 0)
    {
        int hash = s;
        hash += o;
        Random.InitState(hash);
    }
}
