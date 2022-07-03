using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] float spawnIntervalShorteningFactor;

    new void Start()
    {
        base.Start();
        gameManager.DifficultyUpgrade += ShortenSpawnInterval;
    }

    void ShortenSpawnInterval()
    {
        minSpawnInterval *= spawnIntervalShorteningFactor;
        maxSpawnInterval *= spawnIntervalShorteningFactor;
    }

    public void DelaySpawning(float enemySpawnStopDuration)
    {
        StopAllCoroutines();
        StartCoroutine(HoldOn(enemySpawnStopDuration));
    }

    IEnumerator HoldOn(float enemySpawnStopDuration)
    {
        yield return new WaitForSeconds(enemySpawnStopDuration);
        CreateRandomObject();
        StartCoroutine(Spawn());
    }
}
