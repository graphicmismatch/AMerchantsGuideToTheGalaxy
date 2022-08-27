using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGen : MonoBehaviour
{
    int x = 0, y = 0;
    public Vector2Int minmax;
    public GameObject[] planets;
    List<GameObject> spp = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(Data.getSeed()); 
        Data.setPlanet(-1);

        for (int i = 0; i < 9; i++)
        {
            int t = Random.Range(0, planets.Length);
            float tx = Random.Range(0f, x);
            float ty = Random.Range(0f, y);
            spp.Add(Instantiate(planets[t], new Vector2(tx, ty), Quaternion.identity));
        }

    }


    public void setSeed(string s)
    {
        int hash = s.GetHashCode();
        Random.InitState(hash);
    }
}
