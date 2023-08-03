using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static LogHandler;

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
                        Error(LogCategories.ITEMS, "Unkwown OrbType: {0}", (item as OrbItem).GetOrbType());
                        break;
                }

                // Временный вывод
                Message(LogCategories.ITEMS, "{0} {1} {2}", redOrbsCount, greenOrbsCount, blueOrbsCount);
                break;

            default:
                Error(LogCategories.ITEMS, "Unkwown ItemType: {0}", item.GetItemType());
                break;
        }
    }
}
