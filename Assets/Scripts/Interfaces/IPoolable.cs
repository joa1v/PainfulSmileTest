using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    string PoolTag { get; set; }
    void ReturnToPool();
    void Spawn();
}
