using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSpawner : MonoBehaviour
{
    [SerializeField] private Perk[] perkPrefabs;


    private void Update()
    {
        foreach (Perk perkPrefab in perkPrefabs)
        {
            float randomValue = Random.Range(0f, 100f);

            if (randomValue <= perkPrefab.SpawnPercentage)
            {
                SpawnPerk(perkPrefab.gameObject);
                break;
            }
        }
    }

    private void SpawnPerk(GameObject prefab)
    {
        GameObject newPerk = Instantiate(prefab, transform);
        newPerk.transform.localPosition = GetRandomSpawnPosition();
        newPerk.transform.localRotation = Quaternion.identity;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float min = -7.5f;
        float max = 7.5f;

        float randomX = Random.Range(min, max);
        float randomZ = Random.Range(min, max);

        return new Vector3(randomX, 0.4f, randomZ);
    }
}
