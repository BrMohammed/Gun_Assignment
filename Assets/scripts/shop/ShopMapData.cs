using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    [System.Serializable]
    public class ShopMapData
    {
        public int SelectedIndex;
        public ShopMApItem[] ShopItems;
    }
    [System.Serializable]
    public class ShopMApItem
    {
        public string ItemName;
        public bool IsUnlocked;
        public int UnlockCost;
    }
}

