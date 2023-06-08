using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    private List<GameObject> _pool = new List<GameObject>();
    private int _poolSize = 10;

    [SerializeField] private GameObject _enemyPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_enemyPrefab);
            obj.SetActive(false);
            _pool.Add(obj);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if(!_pool[i].activeInHierarchy)
            {
                return _pool[i];
            }
        }
        return null;
    }
}
