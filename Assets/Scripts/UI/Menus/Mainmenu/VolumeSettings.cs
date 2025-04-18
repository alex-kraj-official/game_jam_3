using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer Master;
    [SerializeField] private Slider mainSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider mainmenuMusicSlider;
    [SerializeField] private Slider gameMusicSlider;
    [SerializeField] private Slider gameEffectsSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("mainVolume"))
        {
            LoadMainVolume();
            LoadMusicVolume();
            LoadMainmenuMusicVolume();
            LoadGameMusicVolume();
            LoadGameEffectsVolume();
        }
        else
        {
            SetMainVolume();
            SetMusicVolume();
            SetMainmenuMusicVolume();
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

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        Master.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    private void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }

    public void SetMainmenuMusicVolume()
    {
        float mainmenuMusicVolume = mainmenuMusicSlider.value;
        Master.SetFloat("mainmenuMusicVolume", mainmenuMusicVolume);
        PlayerPrefs.SetFloat("mainmenuMusicVolume", mainmenuMusicVolume);
    }

    private void LoadMainmenuMusicVolume()
    {
        mainmenuMusicSlider.value = PlayerPrefs.GetFloat("mainmenuMusicVolume");

        SetMainmenuMusicVolume();
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