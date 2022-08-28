using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelShop : MonoBehaviour
{
    public float Fuelprice;
    private void Start()
    {
        Fuelprice = Random.Range(1, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ShopUI ui = FindObjectOfType<ShopUI>();
            ui.Refresh();
            Item it = new Item();
            it.itemName = "Fuel";
            ui.SpawnSellObj(it, Fuelprice);
        }
    }
}
