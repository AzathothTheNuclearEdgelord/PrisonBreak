﻿using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractables{
    public string itemName;
    public float weight;

    private void Start(){
        gameObject.tag = "Interactable";
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Action(PlayerManager player){
        if (player.AddItem(CreateItem()))
            Remove();
    }

    public void Remove(){
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 position){
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);
        gameObject.SetActive(true);
    }

    public abstract Item CreateItem();
}