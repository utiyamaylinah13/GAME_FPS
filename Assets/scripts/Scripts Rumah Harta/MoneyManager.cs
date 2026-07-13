using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [Header("Money")]
    public int totalMoney = 1;

    [Header("UI")]
    public TMP_Text coinText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        totalMoney += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = "Money: " + totalMoney;
    }
}