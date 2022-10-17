using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NPCDialogue
{
    public Sprite image;
    public string name;
    public string[] lines;
}
public class DialogueHolder : MonoBehaviour
{
    public NPCDialogue[] npcs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
