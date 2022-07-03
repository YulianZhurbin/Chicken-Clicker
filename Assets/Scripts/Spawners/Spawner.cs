using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject[] spawnedObjects;
    [SerializeField] protected float minSpawnInterval;
    [SerializeField] protected float maxSpawnInterval;
    [SerializeField] float spawnRangeLimit;
    [SerializeField] float spawnYCoordinate;
    protected GameManager gameManager;

    protected void Start()
    {
        gameManager = GetComponent<GameManager>();
        StartCoroutine(Spawn());
    }

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomObject();
        }
    }

    protected void CreateRandomObject()
    {
        int spawnedObjectIndex = Random.Range(0, spawnedObjects.Length);
        Instantiate(spawnedObjects[spawnedObjectIndex], GetRandomPosition(), spawnedObjects[spawnedObjectIndex].transform.rotation);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-spawnRangeLimit, spawnRangeLimit), spawnYCoordinate, Random.Range(-spawnRangeLimit, spawnRangeLimit));
    }

    protected IEnumerator Spawn()
    {
        while(gameManager.IsGameActive)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            CreateRandomObject();
        }
    }
}
