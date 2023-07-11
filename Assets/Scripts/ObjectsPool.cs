using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _fuelPrefab;
    [SerializeField] private GameObject _rKitPrefab;

    public static ObjectsPool instance;

    private List<GameObject> _enemyPool = new List<GameObject>();
    private int _enemyPoolSize = 10;

    private List<GameObject> _coinPool = new List<GameObject>();
    private int _coinPoolSize = 2;

    private List<GameObject> _fuelPool = new List<GameObject>();
    private int _fuelPoolSize = 1;

    private List<GameObject> _rKitPool = new List<GameObject>();
    private int _rKitPoolSize = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        CreatePool(_enemyPoolSize, _enemyPool, _enemyPrefab);
        //CreatePool(_coinPoolSize, _coinPool, _coinPrefab); DISABLED FOR MVP
        CreatePool(_fuelPoolSize, _fuelPool, _fuelPrefab);
        CreatePool(_rKitPoolSize, _rKitPool, _rKitPrefab);
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

    public GameObject GetPool(int index)
    {
        switch (index)
        {
            case 0:
                return GetPooledEnemy();
            case 1:
                return GetPooledCoin();
            case 2:
                return GetPooledFuel();
            case 3:
                return GetPooledRKit();
            default:
                return null;
        }
    }

    private GameObject GetPooledEnemy()
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

    private GameObject GetPooledCoin()
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

    private GameObject GetPooledFuel()
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
    private GameObject GetPooledRKit()
    {
        for (int i = 0; i < _rKitPool.Count; i++)
        {
            if (!_rKitPool[i].activeInHierarchy)
            {
                return _rKitPool[i];
            }
        }
        return null;
    }
}
