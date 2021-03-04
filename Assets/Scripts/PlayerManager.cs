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

        if (Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2)){
                IInteractables i = hit.collider.gameObject.GetComponent<IInteractables>();
                if (i != null){
                    i.Action(this);
                }
            }
        }
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

    public bool CanOpenDoor(int id){
        return inventory.CanOpenDoor(id);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("Interactable")){
        }
    }
}