using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    private Inventory inventory;
    public float initialMaxWeight = 100;

    private void Start(){
        inventory = new Inventory(initialMaxWeight);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0))
            DropLastItem();
    }

    public bool AddItem(Item item, GameObject gameObject){
        Debug.Log($"Adding item {item.name}");
        return inventory.AddItem(item, gameObject);
    }

    public void DropLastItem(){
        GameObject gameObject = inventory.DropLastItem();
        if (gameObject == null) return;
        gameObject.transform.position = transform.position;
        gameObject.SetActive(true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("Interactable")){
            IInteractables i = hit.gameObject.GetComponent<IInteractables>();
            i.Action(this);
        }
    }
}
