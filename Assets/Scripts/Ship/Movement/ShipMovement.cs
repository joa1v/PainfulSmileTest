using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotationSpeed;
    private bool _canMove = true;
    public int Speed { get => _speed; set => _speed = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public Rigidbody2D Rb => _rb;

    public void RotateShip(Vector3 axis, float angle)
    {
        angle *= _rotationSpeed * Time.deltaTime;
        transform.Rotate(axis, angle * -1);
    }

    public void RotateShipToDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    public void Move()
    {
        if (!_canMove)
            return;

        _rb.velocity = transform.up * _speed * Time.deltaTime;
    }

    public void Stop()
    {
        _rb.velocity = Vector2.zero;
    }

    public void DisableMovement()
    {
        _canMove = false;
        _rb.Sleep();
        _rb.isKinematic = true;
    }

    public void EnableMovement()
    {
        _canMove = true;
        _rb.isKinematic = false;
    }
}
