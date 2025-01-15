using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class ShopMapUi : MonoBehaviour
    {
        public int HighScore;
        public ShopMapData ShopMapDataUI;
        public GameObject[] Maps;
        public Text UnlockBtnText, Name;
        public Button Next, Prev, Select;
        private int curentIndex = 0;
        private int SelectedIndex = 0;
        public SaveLodeData saveLodeData;
        public GameObject SoundObj;
        private int MapsSelect;
        void Start()
        {
            HighScore = int.Parse(SimpelDb.read("score"));
            saveLodeData.Initialized();
            SelectedIndex = ShopMapDataUI.SelectedIndex;
            curentIndex = SelectedIndex;
            Next.onClick.AddListener(() => NextBtnMeth());
            Prev.onClick.AddListener(() => PrevBtnMeth());
            Select.onClick.AddListener(() => SelectBtnMeth());
            setinfo();
            Maps[curentIndex].SetActive(true);
            Select.gameObject.SetActive(false);
            if (curentIndex == 0) Prev.gameObject.SetActive(false);
            if (curentIndex == ShopMapDataUI.ShopItems.Length - 1) Next.gameObject.SetActive(false);
            Name.text = ShopMapDataUI.ShopItems[curentIndex].ItemName;
        }
        private void setinfo()
        {
            if (ShopMapDataUI.ShopItems[curentIndex].UnlockCost == 0)
            {
                Select.interactable = true;
                UnlockBtnText.text = "Select";
            }
            else
            {

                if (HighScore >= ShopMapDataUI.ShopItems[curentIndex].UnlockCost)
                    Select.interactable = true;
                else
                    Select.interactable = false;
                UnlockBtnText.text = ShopMapDataUI.ShopItems[curentIndex].UnlockCost.ToString() + " / " + HighScore.ToString();
            }
        }

        private void NextBtnMeth()
        {
            UiAnimeShop.butten_haver(Next.gameObject);
            SoundObj.SetActive(false);
            if (curentIndex < ShopMapDataUI.ShopItems.Length - 1)
            {
                FindObjectOfType<AudioManager>().PlaySound("click");
                Maps[curentIndex].SetActive(false);
                curentIndex++;
                Maps[curentIndex].SetActive(true);
                setinfo();
                if (curentIndex == ShopMapDataUI.ShopItems.Length - 1) Next.gameObject.SetActive(false);
                if (Prev.gameObject.activeSelf == false) Prev.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
            Name.text = ShopMapDataUI.ShopItems[curentIndex].ItemName;
            string shopMapDataString = SimpelDb.read("SaveMapDataShop");
            MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
            if (curentIndex == MapsSelect)
                Select.gameObject.SetActive(false);
        }

        private void PrevBtnMeth()
        {
            UiAnimeShop.butten_haver(Prev.gameObject);
            SoundObj.SetActive(false);
            if (curentIndex > 0)
            {
                FindObjectOfType<AudioManager>().PlaySound("click");
                Maps[curentIndex].SetActive(false);
                curentIndex--;
                Maps[curentIndex].SetActive(true);
                setinfo();
                if (curentIndex == 0) Prev.gameObject.SetActive(false);
                if (Next.gameObject.activeSelf == false) Next.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
            string shopMapDataString = SimpelDb.read("SaveMapDataShop");
            MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
            if (curentIndex == MapsSelect)
                Select.gameObject.SetActive(false);
            Name.text = ShopMapDataUI.ShopItems[curentIndex].ItemName;
        }
        private void SelectBtnMeth()
        {
            UiAnimeShop.butten_haver(Select.gameObject);
            SoundObj.SetActive(false);
            FindObjectOfType<AudioManager>().PlaySound("click");
            bool yes_is_selected = false;
            if (ShopMapDataUI.ShopItems[curentIndex].IsUnlocked == true)
                yes_is_selected = true;
            if (HighScore >= ShopMapDataUI.ShopItems[curentIndex].UnlockCost)
            {
                ShopMapDataUI.ShopItems[curentIndex].UnlockCost = 0;
                UnlockBtnText.text = "Select";
                yes_is_selected = true;
                ShopMapDataUI.ShopItems[curentIndex].IsUnlocked = true;
                saveLodeData.SaveMapData();
            }
            if (yes_is_selected == true)
            {
                UnlockBtnText.text = "Select";
                SelectedIndex = curentIndex;
                ShopMapDataUI.SelectedIndex = SelectedIndex;
                Select.gameObject.SetActive(false);
                saveLodeData.SaveMapData();
            }
        }

    }
}
