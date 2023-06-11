using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public static ObjectsPool instance;

    private List<GameObject> _enemyPool = new List<GameObject>();
    private int _enemyPoolSize = 10;

    private List<GameObject> _coinPool = new List<GameObject>();
    private int _coinPoolSize = 2;

    private List<GameObject> _fuelPool = new List<GameObject>();
    private int _fuelPoolSize = 1;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _fuelPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        CreatePool(_enemyPoolSize, _enemyPool, _enemyPrefab);
        CreatePool(_coinPoolSize, _coinPool, _coinPrefab);
        CreatePool(_fuelPoolSize, _fuelPool, _fuelPrefab);
    }

    private void CreatePool(int poolSize, List<GameObject> pool, GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < _enemyPool.Count; i++)
        {
            if(!_enemyPool[i].activeInHierarchy)
            {
                return _enemyPool[i];
            }
        }
        return null;
    }

    public GameObject GetPooledCoin()
    {
        for (int i = 0; i < _coinPool.Count; i++)
        {
            if (!_coinPool[i].activeInHierarchy)
            {
                return _coinPool[i];
            }
        }
        return null;
    }

    public GameObject GetPooledFuel()
    {
        for (int i = 0; i < _fuelPool.Count; i++)
        {
            if (!_fuelPool[i].activeInHierarchy)
            {
                return _fuelPool[i];
            }
        }
        return null;
    }
}