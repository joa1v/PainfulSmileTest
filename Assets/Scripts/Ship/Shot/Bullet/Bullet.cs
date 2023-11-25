using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable, IMoveable
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _timeToStayActive;
    private float _timeSpawned;
    public string PoolTag { get; set; }
    public int Speed { get => _speed; set => _speed = value; }

    public Rigidbody2D Rb => _rb;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Time.time > _timeSpawned + _timeToStayActive)
        {
            ReturnToPool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPoints ship = collision.gameObject.GetComponent<HealthPoints>();
        if (ship)
        {
            ship.TakeDamage(_damage);
            BulletCollisionEffects();
        }

        ReturnToPool();
    }

    public void ReturnToPool()
    {
        ObjectPooler.Instance.ReturnToPool(PoolTag, gameObject);
    }

    public void Move()
    {
        _rb.velocity = transform.right.normalized * _speed * Time.deltaTime;
    }

    public void Stop()
    {

    }

    private void BulletCollisionEffects()
    {

    }

    public void Spawn()
    {
        _timeSpawned = Time.time;
    }
}
