using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;

    public GameObject btnSoundOn;
    public GameObject btnSoundOff;

    private bool isMute = false;

    void Start()
    {
        UpdateUI();
    }

    public void ToggleSound()
    {
        isMute = !isMute;

        bgm.mute = isMute;

        UpdateUI();
    }

    void UpdateUI()
    {
        btnSoundOn.SetActive(!isMute);
        btnSoundOff.SetActive(isMute);
    }
}