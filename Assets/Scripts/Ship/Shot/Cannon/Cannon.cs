using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _shotCooldown;
    protected bool _canShoot = true;
    private float _lastShotTime;

    public virtual void Shoot()
    {
        if (!_canShoot)
            return;

        _lastShotTime = Time.time;
        _canShoot = false;
    }

    private void Update()
    {
        CheckShotCooldown();
    }

    private void CheckShotCooldown()
    {
        if (Time.time > _lastShotTime + _shotCooldown)
        {
            _canShoot = true;
        }
    }

}
