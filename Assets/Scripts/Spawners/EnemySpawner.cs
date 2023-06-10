using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    private float previousSpawnPoint = 100f;
    private float spawnOffset = 0.65f;

    private void Start()
    {
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            float xToSpawn = Random.Range(-2.8f, 2.8f);

            if (Mathf.Abs(xToSpawn - previousSpawnPoint) < spawnOffset)
            {
                float resultOffest = spawnOffset - Mathf.Abs(xToSpawn - previousSpawnPoint);
                xToSpawn += xToSpawn > 0f ? resultOffest : -resultOffest;

                if (xToSpawn > 2.8f)
                {
                    xToSpawn = -xToSpawn + resultOffest;
                }
                else if (xToSpawn < -2.8f)
                {
                    xToSpawn = -xToSpawn - resultOffest;
                }
            }
            //GameObject enemy = Instantiate(_enemy, new Vector2(xToSpawn, transform.position.y), Quaternion.identity);

            GameObject enemy = ObjectsPool.instance.GetPooledEnemy();

            if (enemy != null)
            {
                enemy.transform.position = new Vector2(xToSpawn, transform.position.y);
                enemy.SetActive(true);
                previousSpawnPoint = xToSpawn;
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
