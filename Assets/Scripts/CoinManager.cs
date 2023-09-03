using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int currentCoins = 0;
    public Text coinText;

    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // PlayerPref'den Coin miktarını yükle
        currentCoins = PlayerPrefs.GetInt("CurrentCoins", 0);      
    }

    private void Update()
    {
        PlayerPrefs.SetInt("CurrentCoins", currentCoins);
        UpdateCoinText();
    }
    
    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinText();
    }


    // Diğer işlevler ve kodlar

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + currentCoins.ToString();
        }
    }

    public void clearDatas()
    {
        PlayerPrefs.DeleteAll();
    }
}

/*public static CoinManager instance; satırı, bir "singleton" tasarım deseni uygulamak için kullanılır. Singleton deseni, bir sınıfın yalnızca bir örneğine sahip olduğundan ve bu örneğe genel bir noktadan erişilebildiğinden emin olmak için kullanılır.

Bu tasarım deseni, özellikle oyunlarda veya uygulamalarda belirli nesnelere global bir erişim sağlamak için kullanışlıdır. CoinManager örneğinde, instance değişkeni, oyunun herhangi bir yerinden CoinManager sınıfına erişmenizi sağlar. Bu sayede, Coin miktarını güncellemek veya metin nesnesine yazdırmak gibi işlemleri kolayca yapabilirsiniz.

Örneğin, başka bir script içinde Coin miktarını artırmak için şu şekilde erişebilirsiniz:

CoinManager.instance.currentCoins += 10;

Bu, instance üzerinden CoinManager'a erişerek currentCoins değerini güncellemenizi sağlar.*/