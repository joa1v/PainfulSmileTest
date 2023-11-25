using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private Cannon _singleCannon;
    [SerializeField] private MultipleCannon _multipleCannon;

    public HealthPoints HealthPoints => _healthPoints;

    protected override void OnEnable()
    {
        base.OnEnable();
        _inputs.OnLeftMouseButtonPressed += SingleShoot;
        _inputs.OnRightMouseButtonPressed += MultipleShot;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _inputs.OnLeftMouseButtonPressed -= SingleShoot;
        _inputs.OnRightMouseButtonPressed -= MultipleShot;
    }

    private void FixedUpdate()
    {
        if (_inputs.MoveShip)
        {
            _movement.Move();
        }
        else
        {
            _movement.Stop();
        }
    }

    private void Update()
    {
        _movement.RotateShip(Vector3.forward, _inputs.X);
    }

    #region Shot
    public void SingleShoot()
    {
        _singleCannon.Shoot();
    }

    private void MultipleShot()
    {
        _multipleCannon.Shoot();
    }

    #endregion
}
