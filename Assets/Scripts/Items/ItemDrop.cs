using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("I: Picked item");
            inventory.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}
