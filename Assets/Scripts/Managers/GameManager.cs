using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameUIController gameUIController;
    RecordManager recordManager;
    [SerializeField] int difficultyUpgradeScoreInterval = 15;
    readonly float scoreIncreaseInterval = 1.0f;
    int score;
    int monsterCount = 10;
    bool isGameActive = true;
    Action difficultyUpgrade;

    public bool IsGameActive
    {
        get { return isGameActive; }
        set { isGameActive = value; }
    }

    public event Action DifficultyUpgrade
    {
        add { difficultyUpgrade += value; }
        remove { difficultyUpgrade -= value; }
    }

    void Start()
    {
        gameUIController = GetComponent<GameUIController>();
        recordManager = GetComponent<RecordManager>();
        StartCoroutine(IncreaseScore());
    }

    void Update()
    {
        if (monsterCount < 1)
        {
            StopGame();
        }

        //HACK: Remove before building
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopGame();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            difficultyUpgrade.Invoke();
        }
#endif
    }


    public void IncreaseMonsterCount()
    {
        monsterCount++;
        gameUIController.ChangeMonsterCountText(monsterCount);
    }

    public void DecreaseMonsterCount()
    {
        monsterCount--;
        gameUIController.ChangeMonsterCountText(monsterCount);
    }

    IEnumerator IncreaseScore()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(scoreIncreaseInterval);
            score++;
            CheckUpgrade();
            gameUIController.ChangeScoreText(score);
        }    
    }

    void StopGame()
    {
        isGameActive = false;
        gameUIController.ShowGameOverText();
        gameUIController.ShowReturnToMenuButton();
        recordManager.CheckRecord(score);
    }

    void CheckUpgrade()
    {
        bool gameUpgrade = (score % difficultyUpgradeScoreInterval == 0) && (score != 0);
        if (gameUpgrade)
        {
            difficultyUpgrade.Invoke();
        }
    }
}
