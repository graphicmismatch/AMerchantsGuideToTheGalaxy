using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoseSceneScript : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Game Over! You Survived " + Data.getDay() + " days";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
