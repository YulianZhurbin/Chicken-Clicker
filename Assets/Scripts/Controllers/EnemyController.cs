using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;
    EnemyPropertyManager enemyPropertyManager;
    ParticleManager particleManager;
    SoundManager soundManager;
    Rigidbody enemyRb;    
    [SerializeField] float constDestinationCoordinate;
    [SerializeField] float destinationChangeInterval;
    Vector3 currentDestination;
    readonly int numberOfWalls = 4;
    float speed;
    int touchesLeft;

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Game Manager");

        gameManager = gameManagerObject.GetComponent<GameManager>();
        gameManager.DecreaseMonsterCount();

        enemyPropertyManager = gameManagerObject.GetComponent<EnemyPropertyManager>();
        speed = enemyPropertyManager.Speed;
        touchesLeft = enemyPropertyManager.TouchesLeft;

        particleManager = gameManagerObject.GetComponent<ParticleManager>();

        soundManager = gameManagerObject.GetComponent<SoundManager>();
        soundManager.PlaySpawnSound();

        enemyRb = GetComponent<Rigidbody>();

        StartCoroutine(ChangeCurrentDestination());
    }

    void Update()
    {
        if(gameManager.IsGameActive)
        {
            enemyRb.AddForce(currentDestination.normalized * speed);
            transform.LookAt(currentDestination);
        }
    }

    private void OnMouseDown()
    {
        if(gameManager.IsGameActive)
        {
            if(touchesLeft > 0)
            {
                soundManager.PlayDestructionSound();
                touchesLeft--;
            }
            else
            {
                GetDestroyed();
            }
        }
    }

    private IEnumerator ChangeCurrentDestination()
    {
        while(true)
        {
            int wallIndex = Random.Range(0, numberOfWalls);

            switch (wallIndex)
            {
                case 0:
                    currentDestination = new Vector3(-constDestinationCoordinate, 0, Random.Range(-constDestinationCoordinate, constDestinationCoordinate));
                    break;
                case 1:
                    currentDestination = new Vector3(Random.Range(-constDestinationCoordinate, constDestinationCoordinate), 0, constDestinationCoordinate);
                    break;
                case 2:
                    currentDestination = new Vector3(constDestinationCoordinate, 0, Random.Range(-constDestinationCoordinate, constDestinationCoordinate));
                    break;
                case 3:
                    currentDestination = new Vector3(Random.Range(-constDestinationCoordinate, constDestinationCoordinate), 0, -constDestinationCoordinate);
                    break;
            }

            yield return new WaitForSeconds(destinationChangeInterval);
        }       
    }

    public void GetDestroyed()
    {
        gameManager.IncreaseMonsterCount();
        soundManager.PlayDestructionSound();
        particleManager.Explode(gameObject.transform.position);
        Destroy(gameObject);
    }
}
