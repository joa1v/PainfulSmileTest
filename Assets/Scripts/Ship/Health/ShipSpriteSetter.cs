using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpriteSetter : MonoBehaviour
{
    [SerializeField] private HealthPoints _healthPoints;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private ShipSprites _sprites;

    [SerializeField, Range(0, 100)] private int _percentageToSetDamaged;

    private void OnEnable()
    {
        _healthPoints.OnHealthPointsChanged += SetSprite;
        ResetSprite();
    }

    private void OnDisable()
    {
        _healthPoints.OnHealthPointsChanged -= SetSprite;
    }
    public void SetSprite(int hp, int maxHp)
    {
        float fill = Mathf.InverseLerp(0, maxHp, hp);

        fill *= 100;

        if (fill < _percentageToSetDamaged && fill > 0)
        {
            _renderer.sprite = _sprites.DamagedSprite;
        }
        else if (fill <= 0)
        {
            _renderer.sprite = _sprites.DeadSprite;
        }
    }

    private void ResetSprite()
    {
        _renderer.sprite = _sprites.NormalSprite;
    }

    public void SetBurnedSprite()
    {
        _renderer.sprite = _sprites.BurnedSprite;
    }
}
