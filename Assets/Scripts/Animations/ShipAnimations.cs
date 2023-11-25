using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimations : Animations
{
    [SerializeField] private string _explosionTrigger;
    public void PlayExplosionAnim()
    {
        PlayAnimation(_explosionTrigger);
    }
}
