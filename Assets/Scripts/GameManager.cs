using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    private Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();
    public UIManager ui;

    private void Awake(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterPickupItem(Pickup item){
        if (!worldItems.ContainsKey(item.itemName)){
            worldItems.Add(item.itemName, item);
        }
        else{
            Debug.LogError($"Object with name \"{item.itemName}\" already exists. There can't be two items with the same name");
        }
    }
    
    public void DropItem(string itemName, Vector3 position){
        worldItems[itemName].Respawn(position);
    }
    
    public Pickup GetPickupWithName(string name)
    {
        return worldItems[name];
    }
    public void TriggerInventoryUIUpdate()
    {
        ui.UpdateInventoryUI();
    }

}
