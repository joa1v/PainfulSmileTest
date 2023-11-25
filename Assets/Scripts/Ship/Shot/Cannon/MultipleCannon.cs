using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCannon : Cannon
{
    [SerializeField] private SingleCannon[] _cannons;

    public override void Shoot()
    {
        if (!_canShoot)
            return;

        base.Shoot();

        foreach (var cannon in _cannons)
        {
            cannon.Shoot();
        }
    }
}
