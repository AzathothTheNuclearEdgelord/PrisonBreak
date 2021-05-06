using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public GameObject content;
    public GameObject inventoryItemPrefab;
    public PlayerManager trackingPlayer;

    public void UpdateUI() {
        ClearItems();
        string[] names = trackingPlayer.GetItemNames();

        for (int i = 0; i < names.Length; i++) {
            Pickup p = GameManager.Instance.GetPickupWithName(names[i]);

            GameObject go = Instantiate(inventoryItemPrefab, content.transform);
            ItemManager im = go.GetComponent<ItemManager>();
            im.UpdateText(p.itemName);
            // im.UpdateImage(p.sprite);
            im.SetManager(this);
        }
    }

    public void RequestDrop(string name) {
        trackingPlayer.DropItem(name);
    }

    private void ClearItems() {
        for (int i = 0; i < content.transform.childCount; i++) {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }
}