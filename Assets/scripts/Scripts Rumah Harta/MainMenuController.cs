using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu;

    [Header("Panel")]
    public GameObject panelLevel;

    //=========================
    // Start
    //=========================

    private void Start()
    {
        mainMenu.SetActive(true);
        panelLevel.SetActive(false);
    }

    //=========================
    // PLAY
    //=========================

    public void Play()
    {
        mainMenu.SetActive(false);
        panelLevel.SetActive(true);
    }

    //=========================
    // BACK
    //=========================

    public void Back()
    {
        panelLevel.SetActive(false);
        mainMenu.SetActive(true);
    }

    //=========================
    // LEVEL
    //=========================

    public void LEVEL1()
    {
        SceneManager.LoadScene("LEVEL1");
    }

    public void LEVEL2()
    {
        SceneManager.LoadScene("LEVEL2");
    }
}