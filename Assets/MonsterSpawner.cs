using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefabs;
    public GameObject CoinPrefabs;

    [Header("���� Ÿ�̹� ����")]
    public float minSpawninternal = 10f;
    public float maxSpawninternal = 30f;

    [Header("���� Ÿ�̹� ����")]
    [Range(0, 100)]
    public int MonsterSpawnchance = 75;

    public float timer = 0.0f;
    public float nextSpawnTime;

    [Header("���� ���� Ȯ�� ����")]
    [Range(0, 100)]
    public int coinSpawnChance = 100;

    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnTime();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawninternal, maxSpawninternal);
    }

    void SpawnObject()
    {
        Transform spawnTransform = transform;

        int randomValue = Random.Range(0, 100);
        if (randomValue < MonsterSpawnchance)
        {
            Instantiate(MonsterPrefabs, spawnTransform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(CoinPrefabs, spawnTransform.position, Quaternion.identity);
        }
    }
}
