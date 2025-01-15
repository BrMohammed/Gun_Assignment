using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public class ShopData
    {
        public int SelectedIndex;
        public ShopItem[] ShopItems;
    }

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public bool isUnlocked;
        public int unlocCost;
    }
}

