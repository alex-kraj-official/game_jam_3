using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int day = 1;
    public float dayLength = 30f;
    public float taxInterval = 5f; // Time between tax requests
    public GameObject taxPanel; // UI panel that gives the choice
    public TextMeshProUGUI levelText;

    [SerializeField] private GameObject OvrestartBtn;
    [SerializeField] private GameObject OvexitBtn;
    [SerializeField] private GameObject WinrestartBtn;
    [SerializeField] private GameObject WinexitBtn;

    [SerializeField] public GameObject NewDaySound;

    public GameObject gameOverPanel;
    public GameObject gameFinishedPanel;

    private bool waitingForChoice = false;

    public EnemySpawner spawner;
    public ResourceManager manager;
    public TowerPlacer towerPlacer;


    private void Update()
    {
        if (day >= 20)
        {
            winGame();
        }
        if (manager.people<1)
        {
            loseGame();
        }
    }
    void Start()
    {
        InvokeRepeating(nameof(TriggerTaxEvent), (taxInterval+taxInterval/2), taxInterval);
        InvokeRepeating(nameof(NewDay), dayLength, dayLength);

        UpdateLevelUI();
    }
    void TriggerTaxEvent()
    {
        if (!waitingForChoice)
        {
            Time.timeScale = 0f; // Pause game
            towerPlacer.PanelsRemove();
            taxPanel.SetActive(true);
            waitingForChoice = true;
        }
    }
    void NewDay()
    {
        day++;
        levelText.SetText(day.ToString());
        if (day > 1)
        {
            NewDaySound.GetComponentInParent<AudioSource>().Play();
        }
    }
    public void PayWithSheep()
    {
        if (manager.people>2 && manager.sheep>500)
        {
            manager.removePeople(2);
            manager.removeSheep(500);
            Debug.Log("Player paid tax.");
            taxPanel.SetActive(false);
            Time.timeScale = 1f;
            waitingForChoice = false;
        }
    }
    public void PayWithPeople()
    {
        if (manager.people>60)
        {
            manager.removePeople(60);
            Debug.Log("Player paid tax.");
            taxPanel.SetActive(false);
            Time.timeScale = 1f;
            waitingForChoice = false;
        }
    }

    public void FightEnemy()
    {
        Debug.Log("Player chose to fight.");
        taxPanel.SetActive(false);
        Time.timeScale = 1f;
        waitingForChoice = false;

        // Spawn enemy here
        TriggerNextWave();
    }

    public void TriggerNextWave()
    {
        switch (currentLevel)
        {
            case 1: spawner.StartWave1(); break;
            case 2: spawner.StartWave2(); break;
            case 3: spawner.StartWave3(); break;
            case 4: spawner.StartWave4(); break;
            case 5: spawner.StartWave5(); break;
            case 6: spawner.StartWave6(); break;
            case 7: spawner.StartWave7(); break;
            case 8: spawner.StartWave8(); break;
        }

        currentLevel++;
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = currentLevel.ToString();
        }
    }
    public void winGame()
    {
        towerPlacer.PanelsRemove();
        Time.timeScale = 0f;
        gameFinishedPanel.SetActive(true);
    }
    public void loseGame()
    {
        towerPlacer.PanelsRemove();
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
    public void restartGame()
    {
        gameFinishedPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }
    public void exitGame()
    {
        gameOverPanel.SetActive(false);
        Application.Quit();
    }
}
