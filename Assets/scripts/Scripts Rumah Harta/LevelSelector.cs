using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelSelector : MonoBehaviour
{
    public void PindahKeLevel(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}