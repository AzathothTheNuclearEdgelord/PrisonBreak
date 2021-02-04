using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private List<Item> items;
    private float weight;
    private float maxWeight;

    public Inventory(){
        items = new List<Item>();
        weight = 0;
        maxWeight = 100;
    }
    
    public Inventory(float maxWeight) : this(){
        this.maxWeight = maxWeight;
    }
    
    // public bool SetMaxWeight()

    public bool AddItem(Item i){
        if (weight + i.weight <= maxWeight){
            items.Add(i);
            weight += i.weight;
            return true;
        }
        else
            return false;
    }

    public bool RemoveItem(Item i){
        bool success = items.Remove(i);
        if (success)
            weight -= i.weight;

        return success;
    }

    public bool HasItem(Item i){
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id){
        foreach (Item item in items){
            if (item is AccessItem){
                if (((AccessItem) item).OpensDoor(id)){
                    return true;
                }
            }
        }
        return false;
    }

    public int Count(){
        return items.Count;
    }

    public float GetCurrentWeight(){
        return weight;
    }
    
    public void DebugInventory(){
        Debug.Log($"Inventory has {Count()} items");
        Debug.Log($"Total weight {GetCurrentWeight()}");

        foreach (Item item in items){
            Debug.Log($"{item.name} --- {item.weight} weight units");
        }
    }
}