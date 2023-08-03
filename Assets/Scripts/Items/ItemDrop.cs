using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LogHandler;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;

    BaseItem item;

    private void Start()
    {
        item = GetComponent<BaseItem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Message(LogCategories.ITEMS, "Picked item: {0}", item);
            inventory.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}
