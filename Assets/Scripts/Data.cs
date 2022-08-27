using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Data : MonoBehaviour
{
    static int seed;
    static int currplanet = -1;
    static int days = 0;
    float duration = 20f;
    bool dotime;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        dotime = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SpaceScene")
        {
            dotime = true;
        }
        if (SceneManager.GetActiveScene().name == "WinScene"|| SceneManager.GetActiveScene().name == "LoseScene")
        {
            dotime = false;
        }

        if (dotime)
        {
            duration -= Time.deltaTime;
            if (duration <= 0f)
            {
                days++;
                duration = 20f;
            }
        }

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
