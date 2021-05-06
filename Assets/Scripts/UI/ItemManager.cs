using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemManager : MonoBehaviour
{
    public Image image;
    public TMP_Text text;
    private InventoryUI manager;

    public void UpdateText(string name) {
        text.text = name;
    }

    /*
    public void UpdateImage(Sprite sprite) {
        image.sprite = sprite;
    }
    */

    public void SetManager(InventoryUI manager) {
        this.manager = manager;
    }

    public void Drop() {
        manager.RequestDrop(text.text);
    }
}
