using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Planet : MonoBehaviour
{
    public int planetno;
    public AudioClip snd;

    private void Start()
    {
        setSeed(Data.getSeed(), planetno);
        Color color = Color.HSVToRGB(Random.Range(0f, 1f), 0.27f, 0.93f);
        this.GetComponent<SpriteRenderer>().color = color;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Data.setPlanet(planetno);
                AudioSource.PlayClipAtPoint(snd, this.transform.position);
                SceneManager.LoadScene("PlanetScene");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Data.setPlanet(planetno);
                AudioSource.PlayClipAtPoint(snd, this.transform.position);
                SceneManager.LoadScene("PlanetScene");
            }
        }
    }

    public void setSeed(int s, int o = 0)
    {
        int hash = s;
        hash += o;
        Random.InitState(hash);

    }

}
