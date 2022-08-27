using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinSceneScript : MonoBehaviour
{

    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Congratulations! You reached your goal in " + Data.getDay() + " days";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
