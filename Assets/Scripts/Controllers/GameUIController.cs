using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] Text monsterCountText;
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] GameObject returnToMenuButton;

    public void ChangeMonsterCountText(int monsterCount)
    {
        if(monsterCount < 0)
        {
            monsterCount = 0;
        }

        monsterCountText.text = "Chicken Count: " + monsterCount;
    }

    public void ChangeScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void ShowReturnToMenuButton()
    {
        returnToMenuButton.SetActive(true);
    }
}
