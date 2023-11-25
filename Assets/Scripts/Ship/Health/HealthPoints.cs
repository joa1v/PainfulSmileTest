using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    protected int _hp;
    protected bool _isDead;
    public delegate void DeathEventHandler();
    public event DeathEventHandler OnDeath;

    public delegate void HealthPointChangeEventHandler(int currentHp, int maxHp);
    public event HealthPointChangeEventHandler OnHealthPointsChanged;

    public bool IsDead => _isDead;

    private void Awake()
    {
        _hp = _maxHp;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead)
            return;

        _hp -= damage;

        OnHealthPointsChanged?.Invoke(_hp, _maxHp);

        if (_hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }

    public void Die()
    {
        TakeDamage(_hp);
    }

    public void ResetHealth()
    {
        _hp = _maxHp;
        OnHealthPointsChanged?.Invoke(_hp, _maxHp);
        _isDead = false;
    }
}
