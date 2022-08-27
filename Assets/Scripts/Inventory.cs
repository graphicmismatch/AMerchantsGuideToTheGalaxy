using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

[System.Serializable]
public class Item
{
    public int id = 0;
    public string itemName = "item";
    public Color color;
    public float weight;
}

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject slots;
    [SerializeField] TextMeshProUGUI moneyUI, fuelUI;
    [SerializeField] List<Item> items;
    [SerializeField] float weight = 0, maxWeight = 100,
        fuel = 0, maxfuel = 100;
    [SerializeField] int money = 100;
    Dictionary<string, int> stored;

    void Start()
    {
        ChangeAmount(findByName("Gold"), 1);
    }

    public bool CheckInventory(Item item, int amount)
    {
        float val = weight + item.weight * amount;
        if (val <= maxWeight && val >= 0)
        {
            return true;
        }
        return false;
    }

    void SetUI()
    {
        fuelUI.text = "Fuel : " + fuel + "%";
        moneyUI.text = "Money : " + money + "$";

        for(int i = 0; i < slots.transform.childCount; i++)
        {
            TextMeshProUGUI tmptext = slots.transform.GetChild(0).GetChild(0)
                   .GetComponent<TextMeshProUGUI>();

            tmptext.text = "Empty";
            if (stored.Count < i)
            {
                tmptext.text = stored.ElementAt(i).Key + " : " + stored.ElementAt(i).Value;
            }
        }
    }

    public void ChangeAmount(Item item, int amount)
    {
        weight = weight + item.weight * amount;
        if (stored.ContainsKey(item.itemName))
        {
            stored[item.itemName] += amount;
            if(stored[item.itemName] <= 0)
            {
                stored.Remove(item.itemName);
            }
        }
        else if (amount > 0)
        {
            stored.Add(item.itemName, amount);
        }

        SetUI();
    }

    public Item findByName(string itemname)
    {
        return items.Find(itm => itm.itemName == itemname);
    }
    public Item findByID(int id)
    {
        return items.Find(itm => itm.id == id);
    }
}
