using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public static CoinUI instance;
    public TextMeshProUGUI coinText;

    private int coins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateText();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateText();
    }

    void UpdateText()
    {
        coinText.text = "Monedas: " + coins;
    }
}