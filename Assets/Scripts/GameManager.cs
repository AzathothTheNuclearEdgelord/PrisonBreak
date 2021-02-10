using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    private Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();

    private void Awake(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void DorpItem(string itemName, Vector3 position){
        worldItems[itemName].Respawn(position);
    }

    public void RegisterPickupItem(Pickup item){
        if (!worldItems.ContainsKey(item.itemName)){
            worldItems.Add(item.itemName, item);
        }
        else{
            Debug.LogError($"Object with name \"{item.itemName}\" already exists. There can't be two items with the same name");
        }

    }
}
