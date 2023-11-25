using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship, IPoolable
{
    [SerializeField] private float _delayToReturnToPool;
    public string PoolTag { get; set; }

    protected override void OnEnable()
    {
        base.OnEnable();

        _healthPoints.OnDeath += PointsManager.AddPoint;
        _healthPoints.OnDeath += ReturnToPool;
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        _healthPoints.OnDeath -= PointsManager.AddPoint;
        _healthPoints.OnDeath -= ReturnToPool;
    }
    protected virtual void Update()
    {
        if (_healthPoints.IsDead)
            return;

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = PlayerPositionTracker.Instance.PlayerPos - transform.position;
        _movement.RotateShipToDirection(direction);
    }

    public void ReturnToPool()
    {
        StartCoroutine(WaitToReturn());
    }

    private IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(_delayToReturnToPool);
        ObjectPooler.Instance.ReturnToPool(PoolTag, gameObject);
    }

    public void Spawn()
    {
        _healthPoints.ResetHealth();
        EnableMovement();
    }

    protected virtual void EnableMovement()
    {
        _movement.EnableMovement();
    }
}
