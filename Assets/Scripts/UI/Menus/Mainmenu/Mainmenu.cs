using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [Header("PANELS")]
    [SerializeField] private GameObject Mainmenu_Panel;
    [SerializeField] private GameObject Main_Settings_Panel;
    [SerializeField] private GameObject Main_GameSettings_Panel;
    [SerializeField] private GameObject Main_GraphicsSettings_Panel;
    [SerializeField] private GameObject Main_SoundSettings_Panel;
    [SerializeField] private GameObject Main_Info_Panel;
    [SerializeField] private GameObject Trans_Panel;
    [SerializeField] private GameObject EscQuit_Panel;
    [SerializeField] private GameObject Main_Last_Panel_lvl1;
    [SerializeField] private GameObject Main_Last_Panel_lvl2;

    [Header("BUTTONS")]
    [SerializeField] private GameObject EscYesBtn;
    [SerializeField] private GameObject EscNoBtn;

    [Header("AUDIO")]
    [SerializeField] public AudioSource clickBtn_AudioSource;

    private int MainMenu_level = 0;
    private bool BackButtonPressed = false;
    private bool EscMainmenu = false;
    private bool EscQuitPanelActive = false;

    void Start()
    {
        //AudioSource Exception Handling
        if (clickBtn_AudioSource == null)
        {
            Debug.LogError("\"clickBtn_AudioSource\" is not set!");
            return;
        }

        //Searching every buttons amongst children
        Button[] buttons = GetComponentsInChildren<Button>(true);
        //Adding an event listener to every children buttons of this (MainmenuCanvas) gameObject which is to play the click sound
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => clickBtn_AudioSource.Play());
        }

        //if (SceneCounter.MainmenuLoaded == 1)
        //{
        //    DoNotDestroyAudioSource.instance.GetComponent<AudioSource>().Play();
        //}
        //if (SceneCounter.MainmenuLoaded > 1 && SceneCounter.FromLevelSelector == false)
        //{
        //    DoNotDestroyAudioSource.instance.GetComponent<AudioSource>().Play();
        //}
        //if (SceneCounter.FromLevelSelector == false)
        //{
        //    DoNotDestroyAudioSource.instance.GetComponent<AudioSource>().Play();
        //}

        //Initializing
        Time.timeScale = 1f;
        Main_Last_Panel_lvl1 = Main_Settings_Panel;
        Main_Last_Panel_lvl2 = Main_GameSettings_Panel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) BackButtonPressed = true; //In case the user presses Esc store this info
        if (BackButtonPressed) Back(); //If the user pressed Esc then run Back() method

        LoadCurrentPanel(); //Displaying the correct panels
    }

    //Displaying the correct panels
    public void LoadCurrentPanel()
    {
        Mainmenu_Panel.SetActive(MainMenu_level == 0);
        Main_Last_Panel_lvl1.SetActive(MainMenu_level == 1);
        Main_Last_Panel_lvl2.SetActive(MainMenu_level == 2);
    }

    //Stepping back in the mainmenu with Esc or with a Back button
    public void Back()
    {
        if (MainMenu_level > 0)
        {
            MainMenu_level -= 1; //Stepping back in the mainmenu
        }
        else
        {
            EscQuitPanel(); // Show quit panel when back at level 0
        }
        clickBtn_AudioSource.Play(); //Playing the click sound
        BackButtonPressed = false; // Reset flag after action
    }

    //Loading and starting the actual game
    public void Play()
    {
        SceneManager.LoadScene("AlexScene", LoadSceneMode.Single); //Test game scene
        //SceneManager.LoadScene("Game"); //Real game scene
    }

    private void OpenMenu(int level, GameObject panel1, GameObject panel2 = null)
    {
        MainMenu_level = level;

        if (level == 1)
        {
            Main_Last_Panel_lvl1 = panel1;
        }
        else if (level == 2)
        {
            Main_Last_Panel_lvl1 = panel1;
            Main_Last_Panel_lvl2 = panel2;
        }
    }

    public void Settings() => OpenMenu(1, Main_Settings_Panel);
    public void GameSettings() => OpenMenu(2, Main_Settings_Panel, Main_GameSettings_Panel);
    public void GraphicsSettings() => OpenMenu(2, Main_Settings_Panel, Main_GraphicsSettings_Panel);
    public void SoundSettings() => OpenMenu(2, Main_Settings_Panel, Main_SoundSettings_Panel);
    public void Info() => OpenMenu(1, Main_Info_Panel);

    //"Are u sure u want to quit?" Panel
    public void EscQuitPanel()
    {
        if (MainMenu_level == 0 && !EscQuitPanelActive)
        {
            EscQuit_Panel.SetActive(true);
            EscQuitPanelActive = true;
            Trans_Panel.SetActive(true);
        }
        else
        {
            EscQuit_Panel.SetActive(false);
            EscQuitPanelActive = false;
            Trans_Panel.SetActive(false);
        }
    }

    //Are u sure u want to quit?->No
    public void EscNo()
    {
        EscQuit_Panel.SetActive(false);
        EscQuitPanelActive = false;
        Trans_Panel.SetActive(false);
    }

    //Close the whole game
    public void Quit()
    {
        Application.Quit();
    }
}