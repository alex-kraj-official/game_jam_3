using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    [Header("PANELS")]
    [SerializeField] private GameObject Pausemenu_Panel;
    [SerializeField] private GameObject Pause_Settings_Panel;
    [SerializeField] private GameObject Pause_GameSettings_Panel;
    [SerializeField] private GameObject Pause_GraphicsSettings_Panel;
    [SerializeField] private GameObject Pause_SoundSettings_Panel;
    [SerializeField] private GameObject Trans_Panel;
    [SerializeField] private GameObject EscMm_Panel;
    [SerializeField] private GameObject EscQuit_Panel;
    [SerializeField] private GameObject Pause_Last_Panel_lvl1;
    [SerializeField] private GameObject Pause_Last_Panel_lvl2;

    [Header("AUDIO")]
    public AudioSource clickBtn_AudioSource;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private int timeScaleCheck;
    [SerializeField] public bool GameIsPaused = false; //Stores if the game is paused
    [SerializeField] private int Pausemenu_level = -1;
    [SerializeField] private bool EscMmPanelActive = false;
    [SerializeField] private bool EscQuitPanelActive = false;

    private void Start()
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

        QualitySettings.SetQualityLevel(SettingsMenu.qualityIndex_Out);

        //Initializing
        Pausemenu_Panel.SetActive(false);
        Pause_Last_Panel_lvl1 = Pause_Settings_Panel;
        Pause_Last_Panel_lvl2 = Pause_GameSettings_Panel;
    }

    void Update()
    {
        timeScaleCheck = Convert.ToInt32(Time.timeScale);
        CheckInput(); //Detecting if the user presses Esc Button
    }

    //Detecting if the user presses Esc Button
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                if (Pausemenu_level == 0 && !EscMmPanelActive && !EscQuitPanelActive)
                {
                    Resume();
                }
                else
                {
                    EscBack();
                }
            }
            else
            {
                Pause();
            }
            LoadCurrentPanel();
        }
    }

    //Displaying the correct panels
    public void LoadCurrentPanel()
    {
        Pausemenu_Panel.SetActive(Pausemenu_level == 0);
        Pause_Last_Panel_lvl1.SetActive(Pausemenu_level == 1);
        Pause_Last_Panel_lvl2.SetActive(Pausemenu_level == 2);
    }

    //Stepping back in the pausemenu with Esc or with a Back button
    public void EscBack()
    {
        if (!EscMmPanelActive && !EscQuitPanelActive)
        {
            Pausemenu_level -= 1;
        }
        else if (EscMmPanelActive)
        {
            EscMm_Panel.SetActive(false);
            EscMmPanelActive = false;
        }
        else
        {
            EscQuit_Panel.SetActive(false);
            EscQuitPanelActive = false;
        }
        clickBtn_AudioSource.Play();
    }

    public void BtnBack()
    {
        Pausemenu_level -= 1;
        clickBtn_AudioSource.Play();
        LoadCurrentPanel();
    }

    //Unpausing the game
    public void Resume()
    {
        Pausemenu_level = -1;
        Pausemenu_Panel.SetActive(false);
        clickBtn_AudioSource.Play();
        if (!gameManager.waitingForChoice && !gameManager.waitingForStart) Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pausing the game
    void Pause()
    {
        Pausemenu_level = 0;
        clickBtn_AudioSource.Play();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void OpenMenu(int level, GameObject panel1, GameObject panel2 = null)
    {
        Pausemenu_level = level;

        if (level == 1)
        {
            Pause_Last_Panel_lvl1 = panel1;
        }
        else if (level == 2)
        {
            Pause_Last_Panel_lvl1 = panel1;
            Pause_Last_Panel_lvl2 = panel2;
        }
        LoadCurrentPanel();
    }

    public void Settings() => OpenMenu(1, Pause_Settings_Panel);
    public void GameSettings() => OpenMenu(2, Pause_Settings_Panel, Pause_GameSettings_Panel);
    public void GraphicsSettings() => OpenMenu(2, Pause_Settings_Panel, Pause_GraphicsSettings_Panel);
    public void SoundSettings() => OpenMenu(2, Pause_Settings_Panel, Pause_SoundSettings_Panel);

    //public void RestartCheckPoint()
    //{
    //    Resume();
    //}

    //Restarting the current level (reloading scene)
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //"Are u sure u want to return?" Panel
    public void EscMmPanel()
    {
        EscMm_Panel.SetActive(true);
        EscMmPanelActive = true;
        Trans_Panel.SetActive(true);
    }

    //"Are u sure u want to quit?" Panel
    public void EscQuitPanel()
    {
        EscQuit_Panel.SetActive(true);
        EscQuitPanelActive = true;
        Trans_Panel.SetActive(true);
    }

    //Are u sure u want to quit?->No
    public void EscNo()
    {
        if (EscMmPanelActive)
        {
            EscMm_Panel.SetActive(false);
            EscMmPanelActive = false;
        }
        else
        {
            EscQuit_Panel.SetActive(false);
            EscQuitPanelActive = false;
        }
        Trans_Panel.SetActive(false);
    }

    //Returning to the mainmenu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu", LoadSceneMode.Single);
    }

    //Close the whole game
    public void QuitGame()
    {
        Application.Quit();
    }
}