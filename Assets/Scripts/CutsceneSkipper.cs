using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSkipper : MonoBehaviour
{
    public SceneLoader sl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            skip();
        }
    }

    public void skip()
    {
        sl.skiptime();
    }
}
