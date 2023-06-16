using UnityEngine;

public class SpawnerModel : MonoBehaviour
{
    [SerializeField] private float[] _spawnDelays = new float[3];
    [SerializeField] private float[] _initialDelays = new float[3];

    private ObjectSpawner _objectSpawner;

    public float previousSpawnPoint { get; set; } = 100f;
    public float spawnOffset { get; private set; } = 0.85f;

    private void Start()
    {
        _objectSpawner = new ObjectSpawner(this);
        
        for (int i = 0; i <= 2; i++)
        {
            StartCoroutine(_objectSpawner.Generator(i, _initialDelays[i], _spawnDelays[i]));
        }
    }
}
