using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu_Panel;
    [SerializeField] private GameObject MainMenu_Settings_Panel;
    [SerializeField] private GameObject MainMenu_GameSettings_Panel;
    [SerializeField] private GameObject MainMenu_GraphicsSettings_Panel;
    [SerializeField] private GameObject MainMenu_SoundSettings_Panel;
    [SerializeField] private GameObject EscQuit_Panel;
    [SerializeField] private GameObject Trans_Panel;
    [SerializeField] private GameObject MainMenu_Info_Panel;

    [SerializeField] private GameObject EscYesBtn;
    [SerializeField] private GameObject EscNoBtn;

    [SerializeField] private GameObject Last_Panel_lvl1;
    [SerializeField] private GameObject Last_Panel_lvl2;

    public AudioSource clickBtn_AudioSource;

    private int MainMenu_level = 0;

    private bool BackButtonPressed = false;
    private bool EscMainmenu = false;
    private bool EscQuitPanelActive = false;
    private bool TransPanelActive = false;

    void Start()
    {
        if (clickBtn_AudioSource == null)
        {
            Debug.LogError("clickBtn_AudioSource nincs beállítva!");
            return;
        }

        //Minden Button megkeresése a gyerekek között
        Button[] buttons = GetComponentsInChildren<Button>(true);
        
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

        //MouseCursorManager.CursorConfined_Visible();
        Time.timeScale = 1f;
        Last_Panel_lvl1 = MainMenu_Settings_Panel;
        Last_Panel_lvl2 = MainMenu_GameSettings_Panel;
        LoadCurrentPanel();
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    if (EscMainmenu)
        //    {
        //        MouseCursorManager.CursorConfined_Visible();
        //    }
        //    else
        //    {
        //        MouseCursorManager.CursorNone_Visible();
        //    }
        //}
        CheckInput();
    }

    private void FixedUpdate()
    {
        if (BackButtonPressed) Back();
        LoadCurrentPanel();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButtonPressed = true;
            Back();
        }
    }

    public void LoadCurrentPanel()
    {        
        if (MainMenu_level == 0)
        {
            MainMenu_Panel.SetActive(true);
            Last_Panel_lvl1.SetActive(false);
            Last_Panel_lvl2.SetActive(false);
        }
        if (MainMenu_level == 1)
        {
            MainMenu_Panel.SetActive(false);
            Last_Panel_lvl1.SetActive(true);
            Last_Panel_lvl2.SetActive(false);
        }
        if (MainMenu_level == 2)
        {
            MainMenu_Panel.SetActive(false);
            Last_Panel_lvl1.SetActive(false);
            Last_Panel_lvl2.SetActive(true);
        }
    }

    public void Back()
    {
        if (MainMenu_level > 0)
        {
            MainMenu_level -= 1;
        }
        else
        {
            EscQuitPanel();
        }
        clickBtn_AudioSource.Play();
        BackButtonPressed = false;
    }

    //Az elsõ pálya betöltése, a játék indítása.
    public void PlayGame()
    {
        SceneManager.LoadScene("AlexScene", LoadSceneMode.Single);
        //SceneManager.LoadScene("Game");
    }

    public void GeneralSettingsPanel()
    {
        MainMenu_level = 1;
        Last_Panel_lvl1 = MainMenu_Settings_Panel;
    }

    public void GameSettingsPanel()
    {
        MainMenu_level = 2;
        Last_Panel_lvl1 = MainMenu_Settings_Panel;
        Last_Panel_lvl2 = MainMenu_GameSettings_Panel;
    }

    public void GraphicsSettingsPanel()
    {
        MainMenu_level = 2;
        Last_Panel_lvl1 = MainMenu_Settings_Panel;
        Last_Panel_lvl2 = MainMenu_GraphicsSettings_Panel;
    }

    public void SoundSettingsPanel()
    {
        MainMenu_level = 2;
        Last_Panel_lvl1 = MainMenu_Settings_Panel;
        Last_Panel_lvl2 = MainMenu_SoundSettings_Panel;
    }

    public void InfoPanel()
    {
        MainMenu_level = 1;
        Last_Panel_lvl1 = MainMenu_Info_Panel;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EscQuitPanel()
    {
        if (MainMenu_level == 0 && !EscQuitPanelActive)
        {
            EscQuit_Panel.SetActive(true);
            EscQuitPanelActive = true;
            Trans_Panel.SetActive(true);
            TransPanelActive = true;
        }
        else
        {
            EscQuit_Panel.SetActive(false);
            EscQuitPanelActive = false;
            Trans_Panel.SetActive(false);
            TransPanelActive = false;
        }
    }

    public void EscYes()
    {
        Application.Quit();
    }

    public void EscNo()
    {
        EscQuit_Panel.SetActive(false);
        EscQuitPanelActive = false;
        Trans_Panel.SetActive(false);
        TransPanelActive = false;
    }
}