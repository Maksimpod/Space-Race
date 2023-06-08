using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnDelay;

    private float _nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnDelay;
            float xToSpawn = Random.Range(-3, 3);
            //GameObject enemy = Instantiate(_enemy, new Vector2(xToSpawn, transform.position.y), Quaternion.identity);

            GameObject _ourEnemy = EnemyPool.instance.GetPooledEnemy();

            if (_ourEnemy != null)
            {
                _ourEnemy.transform.position = new Vector2(xToSpawn, transform.position.y);
                _ourEnemy.SetActive(true);
            }
        }
    }
}
