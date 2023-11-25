using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : EnemyShip
{
    [SerializeField] private float _distanceToShoot;
    [SerializeField] private Cannon _cannon;

    public float DistanceToShoot => _distanceToShoot;

    protected override void Update()
    {
        if (_healthPoints.IsDead)
            return;

        base.Update();

        float distance = GetDistanceFromPlayer();

        if (distance < _distanceToShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        _cannon.Shoot();
    }

    private float GetDistanceFromPlayer()
    {
        return Vector2.Distance(transform.position, PlayerPositionTracker.Instance.PlayerPos);
    }

    protected override void EnableMovement()
    {
        
    }

}
