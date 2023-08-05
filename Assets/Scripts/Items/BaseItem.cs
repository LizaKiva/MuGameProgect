using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // Тип предмета, для упрощеной идентификации
{
    ITEM,
    GOLD,
    POISON,
    ORB
}

[Serializable]
public class BaseItem : MonoBehaviour // Базовый класс предмета
{
    [SerializeField] private ItemType type;    // Тип предмета
    [SerializeField] private string item_name; // Название предмета

    public string GetItemName() => item_name;
    public ItemType GetItemType() => type;
    public override string ToString() => GetItemName();
}
