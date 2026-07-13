using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject playButton;

    void Start()
    {
        Time.timeScale = 1f;

        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    // Tombol Pause
    public void PauseGame()
    {
        Time.timeScale = 0f;

        pauseButton.SetActive(false);
        playButton.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Tombol Play
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        pauseButton.SetActive(true);
        playButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}