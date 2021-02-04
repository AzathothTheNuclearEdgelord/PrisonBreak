using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour{
    private Inventory inventory;
    void Start(){
        inventory = new Inventory(150);
        //TestCreateItem();
        TestInventoryFunctionality();
    }

    private void TestCreateItem(){
        print("========== Testing Item Creation ==========");
        Item i = new AccessItem("Key of Death", 10, 1);
        DebugItem(i);
        
        Item j = new BonusItem("Potato of the Gods", 2, 100);
        DebugItem(j);
        
    }

    public void DebugItem(Item item){
        string itemInfo = $"Item name is \"{item.name}\" and weighs {item.weight} ";
        string extraInfo = "";

        if (item is AccessItem)
            extraInfo = $"and opens door {((AccessItem) item).doorId}";
        
        else if (item is BonusItem)
            extraInfo = $"and gives you {((BonusItem) item).points}";
        
        print($"{itemInfo}{extraInfo}");
    }

    private void TestInventoryFunctionality(){
        print("========== Testing Inventory Functionality ==========");
        
        Item i = new AccessItem("Key of Doom", 10, 1);
        Item j = new BonusItem("Potato of the Gods", 50, 100);
        Item k = new BonusItem("Potato of Death", 50, 50);

        AddItemToInventory(i);
        AddItemToInventory(j);
        AddItemToInventory(k);
        
        inventory.DebugInventory();

        if (inventory.CanOpenDoor(1))
            print($"Opened the door of Doom aka 1");
        else
            print("Door of Doom not opened");
        
        if (inventory.CanOpenDoor(2))
            print($"Opened the door of Death aka 2");
        else
            print("Door of Death not opened");
    }

    void AddItemToInventory(Item item){
        if (inventory.AddItem(item))
            print($"Added {item.name} to inventory");
        else
            print($"Failed to add {item.name} to inventory");
    }

}
