using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Animator _componentAnimator;

    private void Awake()
     {
        _componentAnimator = GetComponent<Animator>();
     }

    public void SimpleAttackAnimation()
     {
        _componentAnimator.SetBool("Attack", true);
        _componentAnimator.SetBool("run", false);
        _componentAnimator.SetBool("walk", false);
     }

}
