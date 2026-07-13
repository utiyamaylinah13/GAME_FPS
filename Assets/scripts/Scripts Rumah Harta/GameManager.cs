using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Target")]
    public int targetMoney = 0;

    [Header("Money")]
    public int currentMoney = 0;
    public TMP_Text moneyText;

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;
    public TMP_Text gameOverMoneyText;
    public TMP_Text gameOverTimeText;

    [Header("Win Panel")]
    public GameObject winPanel;
    public TMP_Text winMoneyText;

    private bool gameFinished = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

   private void Start()
    {
        UpdateMoneyUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    //====================================================
    // TAMBAH UANG
    //====================================================

    public void AddMoney(int amount)
    {
        if (gameFinished)
            return;

        currentMoney += amount;

        UpdateMoneyUI();

        Debug.Log("Money : " + currentMoney);

        // --- TAMBAHKAN LOGIKA INI ---
        // Cek apakah uang/koin yang terkumpul sudah mencapai atau melewati target
        if (currentMoney >= targetMoney)
        {
            gameFinished = true;
            ShowWin(); // Langsung tampilkan panel menang!
        }
    }

    //====================================================
    // UPDATE UI
    //====================================================

    void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = currentMoney.ToString();
    }

    //====================================================
    // CEK HASIL
    // Dipanggil TimerManager saat waktu habis
    //====================================================

    public void CheckResult(float remainingTime)
    {
        if (gameFinished)
            return;

        gameFinished = true;

        if (currentMoney >= targetMoney)
        {
            ShowWin();
        }
        else
        {
            ShowGameOver(remainingTime);
        }
    }

    //====================================================
    // WIN
    //====================================================

    void ShowWin()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    //====================================================
    // GAME OVER
    //====================================================

    void ShowGameOver(float remainingTime)
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        gameOverMoneyText.text = currentMoney.ToString();
        gameOverTimeText.text = FormatTime(remainingTime);

        Time.timeScale = 0f;
    }
    //====================================================
    // FORMAT TIMER
    //====================================================

    string FormatTime(float time)
    {
        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minute, second);
    }

    //====================================================
    // BUTTON RESTART
    //====================================================

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //====================================================
    // BUTTON NEXT LEVEL
    //====================================================

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Level berikutnya belum ada.");
        }
    }

    //====================================================
    // BUTTON MAIN MENU
    //====================================================

    public void BackToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}