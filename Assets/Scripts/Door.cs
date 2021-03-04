using UnityEngine;

public class Door : MonoBehaviour, IInteractables{
    public int id;
    public int doorForce;
    public bool open = false;
    private float initialRotation;
    private Rigidbody rigidbody;

    void Start(){
        gameObject.tag = "Interactable";
        initialRotation = transform.rotation.eulerAngles.y;
        rigidbody = gameObject.AddComponent<Rigidbody>();
    }

    void Update(){
        if (open){
            rigidbody.AddForce(Vector3.up * doorForce);
        }
        // if (open && transform.rotation.eulerAngles.y < initialRotation + 80){
        //     transform.rotation =
        //         Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, initialRotation + 80, 0), 5);
        // }
        // else if (!open && transform.rotation.eulerAngles.y > initialRotation){
        //     transform.rotation =
        //         Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, initialRotation, 0), 5);
        // }
    }

    public void Open(){
        open = !open;
    }

    public void Action(PlayerManager player){
        if (player.CanOpenDoor(id)){
            Open();
        }
    }
}