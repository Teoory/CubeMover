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

    public ShopItem[] shopHatItems;
    public ShopItem[] shopMouthItems;
    public ShopItem[] shopColorsItems;
    public GameObject blue;
    public Text NotEnoughMoney;

    private void Start()
    {
        LoadshopItems();
    }

    public void BuyItem(int itemIndex)
    {
        if (CoinManager.instance.currentCoins >= shopHatItems[itemIndex].price && !shopHatItems[itemIndex].purchased)
        {
            CoinManager.instance.currentCoins -= shopHatItems[itemIndex].price;
            shopHatItems[itemIndex].purchased = true;
            shopHatItems[itemIndex].buyButton.gameObject.SetActive(false);
            shopHatItems[itemIndex].useButton.gameObject.SetActive(true);
    
            // Ayrı ayrı kaydetme
            PlayerPrefs.SetInt($"Item_{itemIndex}_Purchased", 1);
    
            SaveshopItems();
        }else
        {
            NotEnoughMoney.gameObject.SetActive(true);
            Invoke("NotEnoguhClose", 1.2f);
        }
    }

    public void BuyMouthItem(int itemIndex)
    {
        if (CoinManager.instance.currentCoins >= shopMouthItems[itemIndex].price && !shopMouthItems[itemIndex].purchased)
        {
            CoinManager.instance.currentCoins -= shopMouthItems[itemIndex].price;
            shopMouthItems[itemIndex].purchased = true;
            shopMouthItems[itemIndex].buyButton.gameObject.SetActive(false);
            shopMouthItems[itemIndex].useButton.gameObject.SetActive(true);
    
            // Ayrı ayrı kaydetme
            PlayerPrefs.SetInt($"Item_Mouth_{itemIndex}_Purchased", 1);
    
            SaveshopItems();
        }else
        {
            NotEnoughMoney.gameObject.SetActive(true);
            Invoke("NotEnoguhClose", 1.2f);
        }
    }

    public void BuyColorsItem(int itemIndex)
    {
        if (CoinManager.instance.currentCoins >= shopColorsItems[itemIndex].price && !shopColorsItems[itemIndex].purchased)
        {
            CoinManager.instance.currentCoins -= shopColorsItems[itemIndex].price;
            shopColorsItems[itemIndex].purchased = true;
            shopColorsItems[itemIndex].buyButton.gameObject.SetActive(false);
            shopColorsItems[itemIndex].useButton.gameObject.SetActive(true);
    
            // Ayrı ayrı kaydetme
            PlayerPrefs.SetInt($"Item_Colors_{itemIndex}_Purchased", 1);
    
            SaveshopItems();
        }else
        {
            NotEnoughMoney.gameObject.SetActive(true);
            Invoke("NotEnoguhClose", 1.2f);
        }
    }

    public void NotEnoguhClose()
    {
        NotEnoughMoney.gameObject.SetActive(false);
    }

    public void UseItem(int itemIndex)
    {
        for (int i = 0; i < shopHatItems.Length; i++)
        {
            shopHatItems[i].hatObject.SetActive(false);
            // shopHatItems[i].useButton.gameObject.SetActive(false);
            shopHatItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }
        
        if (shopHatItems[itemIndex].purchased && !shopHatItems[itemIndex].used)
        {
            shopHatItems[itemIndex].used = true;
            // shopHatItems[itemIndex].useButton.gameObject.SetActive(false);
            shopHatItems[itemIndex].hatObject.SetActive(true);
            SaveshopItems();
        }
    }

    public void UseMouthItem(int itemIndex)
    {
        for (int i = 0; i < shopMouthItems.Length; i++)
        {
            shopMouthItems[i].hatObject.SetActive(false);
            // shopMouthItems[i].useButton.gameObject.SetActive(false);
            shopMouthItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_Mouth_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }

        if (shopMouthItems[itemIndex].purchased && !shopMouthItems[itemIndex].used)
        {
            shopMouthItems[itemIndex].used = true;
            // shopMouthItems[itemIndex].useButton.gameObject.SetActive(false);
            shopMouthItems[itemIndex].hatObject.SetActive(true);
            SaveshopItems();
        }
    }

    public void UseColorsItem(int itemIndex)
    {
        for (int i = 0; i < shopColorsItems.Length; i++)
        {
            shopColorsItems[i].hatObject.SetActive(false);
            // shopColorsItems[i].useButton.gameObject.SetActive(false);
            shopColorsItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_Colors_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }

        if (shopColorsItems[itemIndex].purchased && !shopColorsItems[itemIndex].used)
        {
            shopColorsItems[itemIndex].used = true;
            // shopColorsItems[itemIndex].useButton.gameObject.SetActive(false);
            shopColorsItems[itemIndex].hatObject.SetActive(true);
            SaveshopItems();
        }
    }

    public void UseBlue()
    {
        blue.SetActive(true);
        PlayerPrefs.SetInt($"Item_Colors_blue_Used", 1);
        PlayerPrefs.Save();
    }
    public void ClearBlue()
    {
        blue.SetActive(false);
        PlayerPrefs.SetInt($"Item_Colors_blue_Used", 0);
        PlayerPrefs.Save();
    }

    
    public void DontHaveItemClose()
    {
        NotEnoughMoney.gameObject.SetActive(false);
    }

    private void LoadshopItems()
    {
        for (int i = 0; i < shopHatItems.Length; i++)
        {
            shopHatItems[i].purchased = PlayerPrefs.GetInt($"Item_{i}_Purchased", 0) == 1;
            shopHatItems[i].used = PlayerPrefs.GetInt($"Item_{i}_Used", 0) == 1;
    
            shopHatItems[i].buyButton.gameObject.SetActive(!shopHatItems[i].purchased);
            //  Kullanılmışsa ve satın alınmışsa useButton aktiv yapma
            // shopHatItems[i].useButton.gameObject.SetActive(shopHatItems[i].purchased && !shopHatItems[i].used);
            shopHatItems[i].useButton.gameObject.SetActive(shopHatItems[i].purchased);
            shopHatItems[i].hatObject.SetActive(shopHatItems[i].used);
        }

        for (int i = 0; i < shopMouthItems.Length; i++)
        {
            shopMouthItems[i].purchased = PlayerPrefs.GetInt($"Item_Mouth_{i}_Purchased", 0) == 1;
            shopMouthItems[i].used = PlayerPrefs.GetInt($"Item_Mouth_{i}_Used", 0) == 1;
    
            shopMouthItems[i].buyButton.gameObject.SetActive(!shopMouthItems[i].purchased);
            shopMouthItems[i].useButton.gameObject.SetActive(shopMouthItems[i].purchased);
            shopMouthItems[i].hatObject.SetActive(shopMouthItems[i].used);
        }

        for (int i = 0; i < shopColorsItems.Length; i++)
        {
            shopColorsItems[i].purchased = PlayerPrefs.GetInt($"Item_Colors_{i}_Purchased", 0) == 1;
            shopColorsItems[i].used = PlayerPrefs.GetInt($"Item_Colors_{i}_Used", 0) == 1;
    
            shopColorsItems[i].buyButton.gameObject.SetActive(!shopColorsItems[i].purchased);
            shopColorsItems[i].useButton.gameObject.SetActive(shopColorsItems[i].purchased);
            shopColorsItems[i].hatObject.SetActive(shopColorsItems[i].used);
        }

        if (PlayerPrefs.HasKey("Item_Colors_blue_Used") && PlayerPrefs.GetInt("Item_Colors_blue_Used", 0) == 0) 
        {
            blue.SetActive(false);
        }
        else
        {
            blue.SetActive(true);            
        }
    }

    private void SaveshopItems()
    {
        for (int i = 0; i < shopHatItems.Length; i++)
        {
            PlayerPrefs.SetInt($"Item_{i}_Purchased", shopHatItems[i].purchased ? 1 : 0);
            PlayerPrefs.SetInt($"Item_{i}_Used", shopHatItems[i].used ? 1 : 0);
        }

        for (int i = 0; i < shopMouthItems.Length; i++)
        {
            PlayerPrefs.SetInt($"Item_Mouth_{i}_Purchased", shopMouthItems[i].purchased ? 1 : 0);
            PlayerPrefs.SetInt($"Item_Mouth_{i}_Used", shopMouthItems[i].used ? 1 : 0);
        }

        for (int i = 0; i < shopColorsItems.Length; i++)
        {
            PlayerPrefs.SetInt($"Item_Colors_{i}_Purchased", shopColorsItems[i].purchased ? 1 : 0);
            PlayerPrefs.SetInt($"Item_Colors_{i}_Used", shopColorsItems[i].used ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void ClearHats()
    {
        for (int i = 0; i < shopHatItems.Length; i++)
        {
            shopHatItems[i].hatObject.SetActive(false);
            // shopHatItems[i].useButton.gameObject.SetActive(false);
            shopHatItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }

        for (int i = 0; i < shopMouthItems.Length; i++)
        {
            shopMouthItems[i].hatObject.SetActive(false);
            // shopMouthItems[i].useButton.gameObject.SetActive(false);
            shopMouthItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_Mouth_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }

        for (int i = 0; i < shopColorsItems.Length; i++)
        {
            shopColorsItems[i].hatObject.SetActive(false);
            // shopColorsItems[i].useButton.gameObject.SetActive(false);
            shopColorsItems[i].used = false; // "Item_X_Used" durumunu da sıfırlayın
            PlayerPrefs.SetInt($"Item_Colors_{i}_Used", 0); // PlayerPrefs'i güncelleyin
        }
        PlayerPrefs.Save();
    }
}