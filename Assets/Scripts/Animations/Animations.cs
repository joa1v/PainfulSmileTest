using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    protected void PlayAnimation(string animationTrigger)
    {
        _animator.SetTrigger(animationTrigger);
    }
}
