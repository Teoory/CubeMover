using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public GameObject itemObject;
        public int price;
        public Button buyButton;
        public Button useButton;
        public GameObject hatObject;
        public bool purchased;
        public bool used;
    }

    public ShopItem[] shopItems;

    private void Start()
    {
        LoadShopItems();
    }

    public void BuyItem(int itemIndex)
    {
        if (CoinManager.instance.currentCoins >= shopItems[itemIndex].price && !shopItems[itemIndex].purchased)
        {
            CoinManager.instance.currentCoins -= shopItems[itemIndex].price;
            shopItems[itemIndex].purchased = true;
            shopItems[itemIndex].buyButton.gameObject.SetActive(false);
            shopItems[itemIndex].useButton.gameObject.SetActive(true);
    
            // Ayrı ayrı kaydetme
            PlayerPrefs.SetInt($"Item_{itemIndex}_Purchased", 1);
    
            SaveShopItems();
        }
    }

    public void UseItem(int itemIndex)
    {
        if (shopItems[itemIndex].purchased && !shopItems[itemIndex].used)
        {
            shopItems[itemIndex].used = true;
            // shopItems[itemIndex].useButton.gameObject.SetActive(false);
            shopItems[itemIndex].hatObject.SetActive(true);
            SaveShopItems();
        }
    }

    private void LoadShopItems()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].purchased = PlayerPrefs.GetInt($"Item_{i}_Purchased", 0) == 1;
            shopItems[i].used = PlayerPrefs.GetInt($"Item_{i}_Used", 0) == 1;
    
            shopItems[i].buyButton.gameObject.SetActive(!shopItems[i].purchased);
            shopItems[i].useButton.gameObject.SetActive(shopItems[i].purchased && !shopItems[i].used);
            shopItems[i].hatObject.SetActive(shopItems[i].used);
        }
    }

    private void SaveShopItems()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            PlayerPrefs.SetInt($"Item_{i}_Purchased", shopItems[i].purchased ? 1 : 0);
            PlayerPrefs.SetInt($"Item_{i}_Used", shopItems[i].used ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void ClearHats()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].hatObject.SetActive(false);
            shopItems[i].useButton.gameObject.SetActive(false);
            shopItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }
        PlayerPrefs.Save();
    }
}