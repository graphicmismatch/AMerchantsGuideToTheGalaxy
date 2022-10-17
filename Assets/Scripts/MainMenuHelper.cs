using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenuHelper : MonoBehaviour
{

    public TextAsset mainMenulinesTA;
    private List<string> MainMenuLines;
    public TMP_Text lineholder;
    // Start is called before the first frame update
    void Start()
    {
      MainMenuLines = new List<string>();
      MainMenuLines.AddRange(mainMenulinesTA.ToString().Split(";"));
      lineholder.text = MainMenuLines[Random.Range(0, MainMenuLines.Count - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
