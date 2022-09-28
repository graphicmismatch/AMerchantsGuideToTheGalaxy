using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelShop : MonoBehaviour
{
    public float Fuelprice;
    private bool inrange;
    private bool isactive;
    private void Start()
    {
        inrange = false;
        isactive = false;
        Fuelprice = Random.Range(1, 5);
    }
    private void Update()
    {
        if (inrange && Input.GetKeyDown(KeyCode.E) && !isactive)
        {
            show();
        }
        else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && isactive)
        {
            ShopUI ui = FindObjectOfType<ShopUI>(true);
            ui.shop.SetActive(false);
            isactive = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inrange = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inrange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inrange = false;
            if (isactive)
            {
                isactive = false;
                ShopUI ui = FindObjectOfType<ShopUI>(true);
                ui.shop.SetActive(false);
            }
        }
    }


    private void show()
    {
        isactive = true;
        ShopUI ui = FindObjectOfType<ShopUI>(true);
        ui.Refresh();
        Item it = new Item();
        it.itemName = "Fuel";
        int rng = Random.Range(1, 10);
        ui.SpawnBuyObj(it, (Fuelprice * rng) * Random.Range(0.5f, 1.5f), rng);
    }
}
