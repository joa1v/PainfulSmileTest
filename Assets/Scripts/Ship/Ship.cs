using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] protected ShipAnimations _animations;
    [SerializeField] protected ShipMovement _movement;
    [SerializeField] protected HealthPoints _healthPoints;

    [SerializeField] private int _collisionDamage;

    protected virtual void OnEnable()
    {
        _healthPoints.OnDeath += Death;
    }

    protected virtual void OnDisable()
    {
        _healthPoints.OnDeath -= Death;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPoints collisionShip = collision.gameObject.GetComponent<HealthPoints>();

        if (collisionShip && !_healthPoints.IsDead)
        {
            collisionShip.TakeDamage(_collisionDamage);
        }
    }

    private void Death()
    {
        _movement.DisableMovement();
    }
}
