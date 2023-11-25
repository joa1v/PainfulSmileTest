using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipSprites_", menuName = "ScriptableObjects/ShipSprites")]
public class ShipSprites : ScriptableObject
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _damagedSprite;
    [SerializeField] private Sprite _deadSprite;
    [SerializeField] private Sprite _burnedSprite;

    public Sprite NormalSprite => _normalSprite;
    public Sprite DamagedSprite => _damagedSprite;
    public Sprite DeadSprite => _deadSprite;
    public Sprite BurnedSprite => _burnedSprite;

}
