using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Data : MonoBehaviour
{
    static int seed;
    static int currplanet = -1;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
    }
    public static void setSeed(int s)
    {
        seed = s;
    }
    public static void setSeed(string s)
    {
        seed = s.GetHashCode();
    }
    public static int getSeed()
    {
        return seed;
    }
    public static void setPlanet(int s)
    {
        currplanet = s;
    }
    public static int getPlanet()
    {
        return currplanet;
    }
}
