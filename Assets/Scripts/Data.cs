using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    static int seed;
    static int currplanet;
    private void Awake()
    {
        DontDestroyOnLoad(this);
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
