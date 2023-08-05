using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // ��� ��������, ��� ��������� �������������
{
    ITEM,
    GOLD,
    POISON,
    ORB
}

[Serializable]
public class BaseItem : MonoBehaviour // ������� ����� ��������
{
    [SerializeField] private ItemType type;    // ��� ��������
    [SerializeField] private string item_name; // �������� ��������

    public string GetItemName() => item_name;
    public ItemType GetItemType() => type;
    public override string ToString() => GetItemName();
}
