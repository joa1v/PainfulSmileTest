using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimations : Animations
{
    [SerializeField] private string _shotTrigger;

    public void PlayShotAnimation()
    {
        PlayAnimation(_shotTrigger);
    }
}
