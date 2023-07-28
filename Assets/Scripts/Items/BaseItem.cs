using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ITEM,
    GOLD,
    POISON
}

[Serializable]
public class BaseItem
{
    private int id;
    private ItemType type;
    private string name;

    public string GetItemName()
    {
        return name;
    }

    public ItemType GetItemType()
    {
        return type;
    }

    public int GetItemId()
    {
        return id;
    }
}
