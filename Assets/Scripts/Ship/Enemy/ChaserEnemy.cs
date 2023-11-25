using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : EnemyShip
{
    private void FixedUpdate()
    {
        _movement.Move();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        HealthPoints collisionShip = collision.gameObject.GetComponent<HealthPoints>();
        if (collisionShip)
        {
            Explode();
        }
    }

    private void Explode()
    {
        ExplosionEffects();
        _healthPoints.Die();
    }

    private void ExplosionEffects()
    {
        _animations.PlayExplosionAnim();
    }
}
