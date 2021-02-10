using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractables{
    public string itemName;
    public float weight;

    private void Start(){
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player){
        if (player.AddItem(CreateItem(), gameObject))
            gameObject.SetActive(false);
    }

    public abstract Item CreateItem();
}