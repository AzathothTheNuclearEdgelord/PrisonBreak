using System.Collections.Generic;
using UnityEngine;

public class Inventory{
    private List<Item> items;
    private List<GameObject> gameObjects;
    private float weight;
    private float maxWeight;

    public Inventory(){
        items = new List<Item>();
        gameObjects = new List<GameObject>();
        weight = 0;
        maxWeight = 100;
    }

    public Inventory(float maxWeight) : this(){
        this.maxWeight = maxWeight;
    }

    public bool SetMaxWeight(float maximumWeight){
        if (maximumWeight >= weight){
            maxWeight = maximumWeight;
            return true;
        }

        return false;
    }

    public GameObject DropLastItem(){
        GameObject gameObject = RemoveItem(items.Count - 1);
        return gameObject;
    }

    public bool AddItem(Item item, GameObject gameObject){
        bool result = AddItem(item);
        if (result)
            gameObjects.Add(gameObject);

        return result;
    }

    public bool AddItem(Item item){
        if (weight + item.weight <= maxWeight){
            items.Add(item);
            weight += item.weight;
            return true;
        }

        return false;
    }

    public bool RemoveItem(Item item){
        bool success = items.Remove(item);
        if (success)
            weight -= item.weight;

        return success;
    }

    public GameObject RemoveItem(int i){
        if (i < 0) return null;

        bool success = RemoveItem(items[i]);
        if (success){
            GameObject gameObject = gameObjects[i];
            gameObjects.Remove(gameObjects[i]);
            return gameObject;
        }

        return null;
    }

    public bool HasItem(Item item){
        return items.Contains(item);
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