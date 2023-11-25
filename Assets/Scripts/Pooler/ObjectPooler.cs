using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> _pools = new List<Pool>();
    private static ObjectPooler _instance;
    public static ObjectPooler Instance => _instance;

    private void Awake()
    {
        _instance = this;
        CreatePools();
    }


    private void CreatePools()
    {
        for (int i = 0; i < _pools.Count; i++)
        {
            for (int j = 0; j < _pools[i].AmountToPool; j++)
            {
                GameObject obj = Instantiate(_pools[i].Obj);
                obj.SetActive(false);
                _pools[i].PoolQueue.Enqueue(obj);
            }
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        Pool pool = _pools.Where(x => x.Tag == tag).First();
        if (pool != null && pool.PoolQueue.Count > 0)
        {
            GameObject obj = pool.PoolQueue.Dequeue();

            IPoolable poolable = obj.GetComponent<IPoolable>();
            poolable.PoolTag = tag;

            obj.SetActive(true);
            poolable.Spawn();
            return obj;
        }

        return null;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        Pool pool = _pools.Where(x => x.Tag == tag).First();
        obj.SetActive(false);
        pool.PoolQueue.Enqueue(obj);
    }
}


[System.Serializable]
public class Pool
{
    [SerializeField] private string _tag;
    [SerializeField] private GameObject _obj;
    [SerializeField] private int _amountToPool;
    private Queue<GameObject> _poolQueue = new Queue<GameObject>();
    public GameObject Obj => _obj;
    public int AmountToPool => _amountToPool;

    public Queue<GameObject> PoolQueue { get => _poolQueue; set => _poolQueue = value; }
    public string Tag => _tag;
}