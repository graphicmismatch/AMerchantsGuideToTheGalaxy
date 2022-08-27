using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGen : MonoBehaviour
{
    int x = 0, y = 0;
    public Vector2Int xr;
    public Vector2Int yr;
    public GameObject[] planets;
    List<GameObject> spp = new List<GameObject>();
    public GameObject player;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        
        Random.InitState(Data.getSeed()); 

        for (int i = 0; i < 10; i++)
        {
            int t = Random.Range(0, planets.Length);
            float tx = Random.Range(xr.x, xr.y);
            float ty = Random.Range(yr.x, yr.y);
            GameObject a = (Instantiate(planets[t], new Vector2(tx, ty), Quaternion.identity));
            a.GetComponent<Planet>().planetno = spp.Count + 1;
            a.transform.localScale = Random.Range(2f, 4f)*new Vector2(1,1);
            spp.Add(a);
        }
        int go = -1;
        var d = 0;
        foreach (GameObject t in spp)
        {
            if (Mathf.Abs(Vector2.Distance(spp[0].transform.position, t.transform.position)) > d)
            {
                go = spp.IndexOf(t);
               
            }
        }
        GameObject temp = spp[go];
        spp[go] = Instantiate(goal, temp.transform.position, temp.transform.rotation);
        spp[go].transform.localScale = temp.transform.localScale;
        Destroy(temp);

        if (Data.getPlanet() != -1)
        {
            player.transform.position = spp[Data.getPlanet() - 1].transform.position;
        }
        else {
            player.transform.position = spp[0].transform.position;
        }
    }


    public void setSeed(string s)
    {
        int hash = s.GetHashCode();
        Random.InitState(hash);
    }
}
