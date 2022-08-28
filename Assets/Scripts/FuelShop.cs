using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelShop : MonoBehaviour
{
    public float Fuelprice;
    private void Start()
    {
        Fuelprice = Random.Range(1, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ShopUI ui = FindObjectOfType<ShopUI>();
            ui.Refresh();
            Item it = new Item();
            it.itemName = "Fuel";
            int rng = Random.Range(1, 10);
            ui.SpawnBuyObj(it, (Fuelprice * rng)* Random.Range(0.5f, 1.5f), rng);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ShopUI ui = FindObjectOfType<ShopUI>();
            ui.shop.SetActive(false);
        }
    }
}
