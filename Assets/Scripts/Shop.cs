using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> items;
    public List<float> prices;
    ShopUI ui;
    private void Start()
    {
        float basePrice = Random.Range(1, 5); 
        for(int i = 0; i < 4; i++)
        {
            prices.Add(basePrice);
            basePrice += Random.Range(basePrice, basePrice * 10);
        }
    }

    public void SetVal(List<Item> items)
    {
        this.items = items;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ui = FindObjectOfType<ShopUI>();
            ui.Refresh();
            for (int i = 0; i < items.Count; i++)
            {
                int rng = Random.Range(1, 10);
                float rng2 = Random.Range(0.5f, 1.5f);
                ui.SpawnBuyObj(items[i], (prices[i] * rng) * rng2, rng);
                ui.SpawnSellObj(items[i], (prices[i] * rng) * rng2 * 2/3, rng);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ui.shop.SetActive(false);
        }
    }
}
