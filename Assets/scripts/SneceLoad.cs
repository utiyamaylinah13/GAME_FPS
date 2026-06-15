using UnityEngine;
using UnityEngine.SceneManagement;

public class SneceLoad : MonoBehaviour
{
    public void LoadSceneBaru(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Aplikasi keluar");
        Application.Quit();
    }
}
