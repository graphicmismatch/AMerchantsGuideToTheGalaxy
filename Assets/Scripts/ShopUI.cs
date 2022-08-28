using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public Inventory inv;
    public Transform Spawn, Spawn2;
    public GameObject SellButton, shop;
    public AudioClip buy;
    private void Start()
    {
        inv = GetComponent<Inventory>();
    }
    public void Refresh()
    {
        foreach(Transform ob in Spawn)
        {
            Destroy(ob.gameObject);
        }
        foreach (Transform ob in Spawn2)
        {
            Destroy(ob.gameObject);
        }
        shop.SetActive(true);
    }
    public void SpawnBuyObj(Item item, float price, int amount)
    {
        Button ButtonPre = Instantiate(SellButton,Spawn).GetComponent<Button>();
        ButtonPre.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            item.itemName + " X " + Mathf.Abs(amount) + " : " + Mathf.Abs(price).ToString("#.00") + "$";
        ButtonPre.onClick.AddListener(delegate { TryBuy(item,price,amount); });
    }
    public void SpawnSellObj(Item item, float price,int amount)
    {
        Button ButtonPre = Instantiate(SellButton, Spawn2).GetComponent<Button>();
        ButtonPre.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            item.itemName + " X " + Mathf.Abs(amount) + " : " + Mathf.Abs(price).ToString("#.00") + "$";
        ButtonPre.onClick.AddListener(delegate { TrySell(item, price, amount); });
    }

    public void TryBuy(Item item, float price, int amount)
    {
        if (inv.CheckMoney(-price))
        {
            if (item.itemName == "Fuel")
            {
                if (inv.CheckFuel(amount))
                {
                    inv.changeFuel(amount);
                    inv.changeMoney(-price);
                }
            }
            else if (inv.CheckInventory(item,amount))
            {
                inv.ChangeAmount(item, amount);
                inv.changeMoney(-price);
            }
            inv.changeMoney(-price);
            AudioSource.PlayClipAtPoint(buy, shop.transform.position);
        }
    }
    public void TrySell(Item item, float price, int amount)
    {
        if (inv.CheckInventory(item, -amount))
        {
            inv.ChangeAmount(item, -amount);
            inv.changeMoney(price);
        }
    }
}
