using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCannon : Cannon
{
    [SerializeField] private string _bulletTag;
    [SerializeField] private Transform _bulletStartPos;
    [SerializeField] private CannonAnimations _animations;
    public override void Shoot()
    {
        if (!_canShoot)
            return;

        base.Shoot();

        _animations.PlayShotAnimation();

        GameObject bullet = ObjectPooler.Instance.SpawnFromPool(_bulletTag);

        if (bullet != null)
        {
            bullet.transform.position = _bulletStartPos.position;
            bullet.transform.rotation = _bulletStartPos.rotation;
        }
    }
}
