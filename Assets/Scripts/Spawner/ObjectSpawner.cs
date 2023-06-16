using System.Collections;
using UnityEngine;

public class ObjectSpawner
{
    private SpawnerModel _spawnerModel;

    public ObjectSpawner(SpawnerModel spawnerModel)
    {
        _spawnerModel = spawnerModel;
    }

    public IEnumerator Generator(int index, float initialDelay, float _spawnDelay)
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            GameObject Object = ObjectsPool.instance.GetPool(index);

            float xToSpawn = CalculateSpawnPosition();

            if (Object != null)
            {
                Object.transform.position = new Vector2(xToSpawn, _spawnerModel.transform.position.y);
                Object.SetActive(true);
                _spawnerModel.previousSpawnPoint = xToSpawn;
            }

            if (index == 2)
            {
                _spawnDelay += 10f;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
    private float CalculateSpawnPosition()
    {
        float xToSpawn = Random.Range(-2.8f, 2.8f);

        if (Mathf.Abs(xToSpawn - _spawnerModel.previousSpawnPoint) < _spawnerModel.spawnOffset)
        {
            float resultOffest = _spawnerModel.spawnOffset - Mathf.Abs(xToSpawn - _spawnerModel.previousSpawnPoint);
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
        return xToSpawn;
    }
}
