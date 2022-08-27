using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Setup : MonoBehaviour
{
    public TMP_InputField seedbox;
    private string unhashedseed;
    // Start is called before the first frame update
    void Start()
    {
        unhashedseed = ((Mathf.RoundToInt(System.DateTime.UtcNow.ToFileTimeUtc()) + (Random.Range(-10000, 10000))) + "");
        seedbox.text = unhashedseed.GetHashCode() + "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startgame()
    {
        Data.setSeed(unhashedseed);
        
    }
}
