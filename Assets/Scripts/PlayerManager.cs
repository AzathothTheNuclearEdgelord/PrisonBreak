using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    private Inventory inventory;
    public float initialMaxWeight = 100;

    private void Start(){
        inventory = new Inventory(initialMaxWeight);
    }

    public bool AddItem(Item item){
        Debug.Log($"Adding item {item.name}");
        return inventory.AddItem(item);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            DropItem("Key of Death");
        }
    }

    public void DropItem(string name){
        Item item = inventory.GetItemWithName(name);
        if (item != null){
            inventory.RemoveItem(item);
            GameManager.Instance.DorpItem(name, transform.position + transform.forward);
        }
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("Interactable")){
            IInteractables i = hit.gameObject.GetComponent<IInteractables>();
            i.Action(this);
        }
    }
}
