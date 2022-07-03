using UnityEngine;
using UnityEngine.UI;

public class EnemyPropertyManager : MonoBehaviour
{
    GameManager gameManager;
    float speed;
    [SerializeField] float speedIncreaseFactor;
    [SerializeField] int numOfUpgradesBeforeTouchesLeftIncrease = 10;
    int touchesLeft;

    public float Speed
    {
        get { return speed; }
    }
    public int TouchesLeft
    {
        get { return touchesLeft; }
    }

    void Start()
    {
        // for unity editor speed = 2.0f;
        speed = 10.0f;
        gameManager = GetComponent<GameManager>();
        gameManager.DifficultyUpgrade += UpgradeEnemy;
    }

    void UpgradeEnemy()
    {
        IncreaseSpeed();

        if(numOfUpgradesBeforeTouchesLeftIncrease == 0)
        {
            IncreaseTouchesLeft();
            numOfUpgradesBeforeTouchesLeftIncrease = 10;
        }
        else
        {
            numOfUpgradesBeforeTouchesLeftIncrease--;
        }
    }

    void IncreaseSpeed()
    {
        speed *= speedIncreaseFactor;
    }

    void IncreaseTouchesLeft()
    {
        touchesLeft++;
    }

}
