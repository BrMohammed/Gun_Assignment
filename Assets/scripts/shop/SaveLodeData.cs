using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class SaveLodeData : MonoBehaviour
    {

        [SerializeField] private ShopUi shopUi;
        [SerializeField] private ShopMapUi shopmapui;
        public void Initialized()
        {
            if (int.Parse(SimpelDb.read("gamestart")) == 1)
            {
                LoadMapData();
                LoadData();
            }
            else
            {
                SaveData();
                SaveMapData();
                SimpelDb.update(1.ToString(), "gamestart");
            }
        }
        public void SaveData()
        {
            string ShopDataString = JsonUtility.ToJson(shopUi.ShopDataUI);
            SimpelDb.update(ShopDataString, "SaveDataShop");
        }
        public void LoadData()
        {
            string shopDataString = SimpelDb.read("SaveDataShop");
            shopUi.ShopDataUI = new ShopData();
            shopUi.ShopDataUI = JsonUtility.FromJson<ShopData>(shopDataString);
        }
        public void SaveMapData()
        {
            string ShopMapDataString = JsonUtility.ToJson(shopmapui.ShopMapDataUI);
            SimpelDb.update(ShopMapDataString, "SaveMapDataShop");
        }
        public void LoadMapData()
        {
            string ShopMapDataString = SimpelDb.read("SaveMapDataShop");
            shopmapui.ShopMapDataUI = new ShopMapData();
            shopmapui.ShopMapDataUI = JsonUtility.FromJson<ShopMapData>(ShopMapDataString);
        }
        public void ClearData()
        {
           // Debug.Log("Clear");
            SimpelDb.update(0.ToString(), "gamestart");
        }
    }
}



