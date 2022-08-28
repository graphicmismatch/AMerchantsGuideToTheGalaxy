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
    static Inventory inst;
    [SerializeField] GameObject slots;
    [SerializeField] TextMeshProUGUI moneyUI, fuelUI, weightUI;
    [SerializeField] List<Item> items;
    [SerializeField] float weight = 0, maxWeight = 100,
        fuel = 0, maxfuel = 100, modifier = 20;
    [SerializeField] float money = 100;
    Dictionary<string, int> stored = new Dictionary<string, int>();

    void Start()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
            ChangeAmount(items[0], 2);
            SetUI();
        }
        else if(inst != this)
        {
            Destroy(this.gameObject);
        }
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

    public bool CheckMoney(float amount)
    {
        return money >= amount;
    }

    void SetUI()
    {
        moneyUI.text = "Money : " + money.ToString("#.00") + "$";
        fuelUI.text = "Fuel : " + fuel.ToString("#.00") + "%";
        weightUI.text = "Weight : " + weight + " / " + maxWeight;
        Debug.Log(stored.ElementAt(0).Key);
        for(int i = 0; i < slots.transform.childCount; i++)
        {
            TextMeshProUGUI tmptext = slots.transform.GetChild(i).GetChild(0)
                   .GetComponent<TextMeshProUGUI>();

            Debug.Log(tmptext.name);

            tmptext.text = "Empty";
            if (i < stored.ToArray().Length)
            {
                tmptext.text = stored.ElementAt(i).Key + " : " + stored.ElementAt(i).Value;
            }
        }
    }

    public void ChangeAmount(Item item, int amount)
    {
        weight = weight + item.weight * amount;

        Debug.Log(item.itemName);

        bool check = stored.ContainsKey(item.itemName.ToString());
        Debug.Log(check);
        if ( check)
        {
            stored[item.itemName] += amount;
            if(stored[item.itemName] <= 0)
            {
                stored.Remove(item.itemName);
            }
        }
        else
        {
            stored.Add(item.itemName, amount);
        }
        SetUI();
    }

    public void changeMoney(float amount)
    {
        money += amount;
        money = Mathf.Round(money);
        moneyUI.text = "Money : " + money.ToString("#.00") + "$";
    }
    public void changeFuel(float amount)
    {
        fuel += amount * modifier;
        fuelUI.text = "Fuel : " + fuel.ToString("#.00") + "%";
    }

    public void toggle()
    {
        slots.SetActive(!slots.activeInHierarchy);
    }

    public Item findByName(string itemname)
    {
        return items.Find(itm => itm.itemName == itemname);
    }
    public Item findByID(int id)
    {
        return items[id];
    }
}
