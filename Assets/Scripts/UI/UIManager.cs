using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public InventoryUI inventoryUI;


    void Start() {
    }

    void Update() {
        if (Input.GetButtonDown("Inventory")) {
            ToggleInventory();
        }
    }

    void ToggleInventory() {
        // FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        PlayerMovement fpsMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        MouseLook mouseLook = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MouseLook>();
        // MouseLook mouseLook = playerCamera.GetComponent<MouseLook>();


        inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        if (inventoryUI.gameObject.activeSelf) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
            fpsMovement.enabled = false;
        }
        else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.enabled = true;
            fpsMovement.enabled = true;
        }
    }

    public void UpdateInventoryUI() {
        inventoryUI.UpdateUI();
    }
}