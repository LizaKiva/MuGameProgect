using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType
{
    RED,
    GREEN,
    BLUE
}

[Serializable]
public class OrbItem : BaseItem
{
    [SerializeField] private OrbType orbType;

    public OrbType GetOrbType()
    {
        return orbType;
    }
}
