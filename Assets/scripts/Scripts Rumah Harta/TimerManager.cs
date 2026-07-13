using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TMP_Text timerText;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
                timeRemaining = 0;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            gameEnded = true;

            timerText.text = "00:00";

            GameManager.Instance.CheckResult(timeRemaining);
        }
    }
}