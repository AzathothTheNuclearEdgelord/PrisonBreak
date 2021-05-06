using UnityEngine;

public class PlayerManager : MonoBehaviour{
    private Inventory inventory;
    public float initialMaxWeight = 100;

    private void Start(){
        inventory = new Inventory(initialMaxWeight);
    }

    /* Drop specific item
    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            DropItem("Key of Death");
        }
    }
    */
    
    public bool AddItem(Item item){
        /* Old AddItem code
        Debug.Log($"Adding item {item.name}");
        return inventory.AddItem(item);
        */
        bool success = inventory.AddItem(item);
        if (success)
        {
            GameManager.Instance.TriggerInventoryUIUpdate();
        }
        return success;
    }

    public void DropItem(string name){
        Item item = inventory.GetItemWithName(name);
        if (item != null){
            inventory.RemoveItem(item);
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
            GameManager.Instance.TriggerInventoryUIUpdate();
        }
    }

    public string[] GetItemNames() {
        return inventory.GetItemNames();
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("Interactable")){
            IInteractables i = hit.gameObject.GetComponent<IInteractables>();
            i.Action(this);
        }
    }
}
