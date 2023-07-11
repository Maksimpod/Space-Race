using UnityEngine;

public class SpawnerModel : MonoBehaviour
{
    [SerializeField] private float[] _spawnDelays = new float[4];
    [SerializeField] private float[] _initialDelays = new float[4];

    private ObjectSpawner _objectSpawner;

    public float previousSpawnPoint { get; set; } = 100f;
    public float spawnOffset { get; private set; } = 0.85f;

    private void Start()
    {
        _objectSpawner = new ObjectSpawner(this);

        for (int i = 0; i <= 3; i++)
        {
            if (i != 1) //DISABLE COIN SPAWNER ATM
            {
                StartCoroutine(_objectSpawner.Generator(i, _initialDelays[i], _spawnDelays[i]));
            }
        }
    }
}
