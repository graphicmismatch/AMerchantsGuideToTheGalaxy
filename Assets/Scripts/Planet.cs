using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Planet : MonoBehaviour
{
    public int planetno;
    public AudioClip snd;
    private bool coll = false;
    private bool c = true;
    private float t = 0.1f;
    private void Start()
    {
        setSeed(Data.getSeed(), planetno);
        Color color = Color.HSVToRGB(Random.Range(0f, 1f), 0.27f, 0.93f);
        this.GetComponent<SpriteRenderer>().color = color;
        c = true;
        t = 0.1f;
    }

    private void Update()
    {
        t -= Time.deltaTime;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, GetComponent<CircleCollider2D>().radius);
        bool f = false;
        if (c)
        {
            foreach (Collider2D c in hitColliders)
            {
                if (c.tag == "Player")
                { f = true; }
            }
            coll = f;
        }

        if (Input.GetKey(KeyCode.Return) && coll && t<0)
        {
            coll = false;
            c = false;
            Data.setPlanet(planetno);
            AudioSource.PlayClipAtPoint(snd, this.transform.position);
            SceneManager.LoadScene("CutSceneLanding");
        }
    }


    public void setSeed(int s, int o = 0)
    {
        int hash = s;
        hash += o;
        Random.InitState(hash);

    }

}
