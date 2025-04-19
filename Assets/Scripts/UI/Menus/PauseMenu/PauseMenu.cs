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

    public bool GameIsPaused = false; //Stores if the game is paused
    private int Pausemenu_level = -1;
    private bool Pausemenu_BackButtonPressed = false; //Stores if the user pressed Esc or a Back button
    private bool EscPausemenu = false;
    private bool EscMmPanelActive = false;
    private bool EscQuitPanelActive = false;

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
        CheckInput(); //Detecting if the user presses Esc Button

        if (GameIsPaused)
        {
            if (!EscMmPanelActive && !EscQuitPanelActive)
            {
                if (Pausemenu_BackButtonPressed) Back();
                LoadCurrentPanel(); //Displaying the correct panels
            }
            if (EscMmPanelActive)
            {
                EscMm_Panel.SetActive(false);
                Trans_Panel.SetActive(false);
            }
            if (EscQuitPanelActive)
            {
                EscQuit_Panel.SetActive(false);
                Trans_Panel.SetActive(false);
            }
        }
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
                    Pausemenu_BackButtonPressed = true;
                }
            }
            else
            {
                Pausemenu_level = 0;
                Pause_Last_Panel_lvl1 = Pause_Settings_Panel;
                Pause_Last_Panel_lvl2 = Pause_GameSettings_Panel;
                Pause();
                LoadCurrentPanel(); //Displaying the correct panels
            }
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
    public void Back()
    {
        if (Pausemenu_level > 0)
        {
            Pausemenu_level -= 1;
        }
        Pausemenu_BackButtonPressed = false;
        clickBtn_AudioSource.Play();
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
        if (Pausemenu_level == 0 && !EscMmPanelActive)
        {
            EscMm_Panel.SetActive(true);
            EscMmPanelActive = true;
            Trans_Panel.SetActive(true);
        }
        else
        {
            EscMm_Panel.SetActive(false);
            EscMmPanelActive = false;
            Trans_Panel.SetActive(false);
        }
    }

    //"Are u sure u want to quit?" Panel
    public void EscQuitPanel()
    {
        if (Pausemenu_level == 0 && !EscQuitPanelActive)
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
        EscMm_Panel.SetActive(false);
        EscQuit_Panel.SetActive(false);
        EscMmPanelActive = false;
        EscQuitPanelActive = false;
        Trans_Panel.SetActive(false);
    }

    public void ReturnToMmBtn()
    {
        EscMmPanel();
    }

    //Returning to the mainmenu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu", LoadSceneMode.Single);
    }

    public void QuitBtn()
    {
        EscQuitPanel();
    }

    //Close the whole game
    public void QuitGame()
    {
        Application.Quit();
    }
}