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
    [SerializeField] private ItemType type;     // ��� ��������
    [SerializeField] private string item_name;  // �������� ��������
    [SerializeField] private Sprite item_image; // �������� ��������

    // ������ ��� ���� �����
    public string GetItemName() => item_name;
    public ItemType GetItemType() => type;
    public Sprite GetItemImage() => item_image;
    public float GetItemImageWidgh() => GetItemImage().rect.width;
    public float GetItemImageHight() => GetItemImage().rect.height;

    public override string ToString() => GetItemName();
}
