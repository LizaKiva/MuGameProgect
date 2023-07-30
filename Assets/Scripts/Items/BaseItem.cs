using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ITEM,
    GOLD,
    POISON,
    ORB
}

[Serializable]
public class BaseItem : MonoBehaviour
{
    [SerializeField] private ItemType type; // Тип предмета
    [SerializeField] private string name;   // Название предмета

    public string GetItemName()
    {
        return name;
    }

    public ItemType GetItemType()
    {
        return type;
    }
}
