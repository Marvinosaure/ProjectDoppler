using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinAnimatorController : MonoBehaviour
{
    private Animator _componentAnimator;

    private void Awake()
    {
        _componentAnimator = GetComponent<Animator>();
    }

    public void WeaksAttacks()
    {
        _componentAnimator.SetTrigger("weakAttack1");
    }
}