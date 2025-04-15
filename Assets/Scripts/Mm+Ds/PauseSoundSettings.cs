using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseSoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer Master;
    [SerializeField] private Slider mainSlider;
    [SerializeField] private Slider gameMusicSlider;
    [SerializeField] private Slider gameEffectsSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("mainVolume"))
        {
            LoadMainVolume();
            LoadGameMusicVolume();
            LoadGameEffectsVolume();
        }
        else
        {
            SetMainVolume();
            SetGameMusicVolume();
            SetGameEffectsVolume();
        }
    }

    public void SetMainVolume()
    {
        float mainVolume = mainSlider.value;
        Master.SetFloat("mainVolume", mainVolume);
        PlayerPrefs.SetFloat("mainVolume", mainVolume);
    }

    private void LoadMainVolume()
    {
        mainSlider.value = PlayerPrefs.GetFloat("mainVolume");

        SetMainVolume();
    }

    public void SetGameMusicVolume()
    {
        float gameMusicVolume = gameMusicSlider.value;
        Master.SetFloat("gameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("gameMusicVolume", gameMusicVolume);
    }

    private void LoadGameMusicVolume()
    {
        gameMusicSlider.value = PlayerPrefs.GetFloat("gameMusicVolume");

        SetGameMusicVolume();
    }

    public void SetGameEffectsVolume()
    {
        float gameEffectsVolume = gameEffectsSlider.value;
        Master.SetFloat("gameEffectsVolume", gameEffectsVolume);
        PlayerPrefs.SetFloat("gameEffectsVolume", gameEffectsVolume);
    }

    private void LoadGameEffectsVolume()
    {
        gameEffectsSlider.value = PlayerPrefs.GetFloat("gameEffectsVolume");

        SetGameEffectsVolume();
    }
}