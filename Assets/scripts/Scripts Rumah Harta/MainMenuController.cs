using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu;

    [Header("Panel")]
    public GameObject panelLevel;
    public GameObject panelAturanMain;
    public GameObject panelSetting;

    //=========================
    // Start
    //=========================

    private void Start()
    {
        mainMenu.SetActive(true);

        panelLevel.SetActive(false);
        panelAturanMain.SetActive(false);
        panelSetting.SetActive(false);
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
    // ATURAN MAIN
    //=========================

    public void AturanMain()
    {
        mainMenu.SetActive(false);
        panelAturanMain.SetActive(true);
    }

    //=========================
    // SETTING
    //=========================

    public void Setting()
    {
        mainMenu.SetActive(false);
        panelSetting.SetActive(true);
    }

    //=========================
    // BACK
    //=========================

    public void Back()
    {
        panelLevel.SetActive(false);
        panelAturanMain.SetActive(false);
        panelSetting.SetActive(false);

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

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}