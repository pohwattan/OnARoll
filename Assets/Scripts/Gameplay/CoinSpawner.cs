using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    float timePassed = 0f;
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject coinPrefab;
    private static Dictionary<GameObject, GameObject> spawnedCoins = new Dictionary<GameObject, GameObject>();
    private static List<GameObject> availableSpawners = new List<GameObject>();
    Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);


    private void OnEnable()
    {
        EventManager.CoinRushCollected += CoinRush;
    }

    private void OnDisable()
    {
        EventManager.CoinRushCollected -= CoinRush;
    }

    void Start()
    {
        foreach (GameObject spawner in spawners)
        {
            availableSpawners.Add(spawner);
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 5f && spawners.Length > spawnedCoins.Count)
        {
            GameObject randomSpawner = GetRandomAvailableSpawner();
            if (randomSpawner != null)
            {
                GameObject newCoin = Instantiate(coinPrefab, randomSpawner.transform.position, rotation, randomSpawner.transform);
                spawnedCoins.Add(newCoin, randomSpawner);
                availableSpawners.Remove(randomSpawner);
                timePassed = 0f;
            }
        }
    }

    private GameObject GetRandomAvailableSpawner()
    {
        if (availableSpawners.Count <= 0) return null;
        int randomIndex = Random.Range(0, availableSpawners.Count);
        return availableSpawners[randomIndex];
    }

    public static void OnCoinPickedUp(GameObject coin)
    {
        if (spawnedCoins.ContainsKey(coin))
        {
            availableSpawners.Add(spawnedCoins[coin]);
            spawnedCoins.Remove(coin);
        }
    }

    private void CoinRush()
    {
        float randomValue = Random.Range(20, 31);
        for (int i = 0; i <= randomValue; i++)
        {
            SpawnCoin(coinPrefab);
        }
    }

    private void SpawnCoin(GameObject prefab)
    {
        GameObject newCoin = Instantiate(prefab, transform);
        newCoin.transform.localPosition = GetRandomSpawnPosition();
        newCoin.transform.localRotation = Quaternion.Euler(0, 0f, 90f);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float min = -7.5f;
        float max = 7.5f;

        float randomX = Random.Range(min, max);
        float randomZ = Random.Range(min, max);

        return new Vector3(randomX, 0.5f, randomZ);
    }
}
