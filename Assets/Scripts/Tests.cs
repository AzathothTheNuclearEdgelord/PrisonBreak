using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        CreatItem();
    }

    private void CreatItem(){
        Item i = new AccessItem("Key of Death", 10, 1);
        DebugItem(i);
        
        Item j = new BonusItem("Potato of the Gods", 2, 100);
        DebugItem(j);
        
    }

    public void DebugItem(Item item){
        string itemInfo = $"Item name is \"{item.name}\" and weighs {item.weight} ";
        string extraInfo = "";

        if (item is AccessItem){
            AccessItem ai = (AccessItem) item;
            extraInfo = $"and opens door {ai.doorId}";
        }
        else if (item is BonusItem){
            BonusItem bi = (BonusItem) item;
            extraInfo = $"and gives you {bi.points}";
        }
        
        print($"{itemInfo}{extraInfo}");

    }
}
