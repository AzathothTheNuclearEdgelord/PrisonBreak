using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{
    private List<Item> items = new List<Item>();
    private float weight;
    private float maxWeight = 100f;

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

    public bool CanSolveRiddle(string input){
        foreach (Item item in items){
            if (item is PuzzleItem){
                if (((PuzzleItem) item).SolvesRiddle(input)){
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
        print($"Inventory has {Count()} items");
        print($"Total weight {GetCurrentWeight()}");

        foreach (Item item in items){
            print($"{item.name} --- {item.weight} weight units");
        }
    }
}