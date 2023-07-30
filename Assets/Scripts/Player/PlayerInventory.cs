using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<BaseItem> items = new List<BaseItem>();
    
    private int redOrbsCount = 0;
    private int greenOrbsCount = 0;
    private int blueOrbsCount = 0;

    public void AddItem(BaseItem item)
    {
        switch (item.GetItemType())
        {
            case ItemType.ORB:
                switch ((item as OrbItem).GetOrbType())
                {
                    case OrbType.RED:
                        redOrbsCount++;
                        break;
                    case OrbType.GREEN:
                        greenOrbsCount++;
                        break;
                    case OrbType.BLUE:
                        blueOrbsCount++;
                        break;
                    default:
                        Debug.Log("E: Unkwown OrbType!");
                        break;
                }

                // Временный вывод
                Debug.Log(redOrbsCount + " " + greenOrbsCount + " " + blueOrbsCount);
                break;

            default:
                Debug.Log("E: Unkwown ItemType!");
                break;
        }
    }
}
