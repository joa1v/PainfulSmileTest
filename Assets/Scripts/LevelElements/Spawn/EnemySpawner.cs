using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private string[] _enemiesTags;
    [SerializeField] private SpawnArea _spawnArea;
    private float _spawnTime;
    private float _lastTimeSpawned;

    public float SpawnTime => _spawnTime;

    private void Awake()
    {
        _spawnTime = PlayerPrefs.GetInt(PlayerPrefsKeys.EnemySpawnTime);
    }

    private void Update()
    {
        bool timeEnded = GameSessionTimer.SessionTime <= 0;

        if (Time.timeSinceLevelLoad >= _lastTimeSpawned + _spawnTime && !timeEnded)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomId = Random.Range(0, _enemiesTags.Length);

        GameObject enemy = ObjectPooler.Instance.SpawnFromPool(_enemiesTags[randomId]);
        if (enemy != null)
        {
            enemy.transform.position = GetRandomPosition();
        }

        _lastTimeSpawned = Time.timeSinceLevelLoad;
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 min = _spawnArea.GetMinLimits();
        Vector2 max = _spawnArea.GetMaxLimits();

        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        return new Vector2(x, y);
    }
}
