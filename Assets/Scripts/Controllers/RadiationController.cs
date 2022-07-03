using UnityEngine;

public class RadiationController : MonoBehaviour
{
    GameManager gameManager;
    EnemySpawner enemySpawner;
    ParticleManager particleManager;
    SoundManager soundManager;
    [SerializeField] float enemySpawnStopDuration;

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        enemySpawner = gameManagerObject.GetComponent<EnemySpawner>();
        particleManager = gameManagerObject.GetComponent<ParticleManager>();
        soundManager = gameManager.GetComponent<SoundManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive)
        {
            particleManager.Irradiate();
            soundManager.PlayRadiationSound();
            DestroyAllEnemies();
            enemySpawner.DelaySpawning(enemySpawnStopDuration);
            Destroy(gameObject);
        }
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().GetDestroyed();
        }
    }
}
