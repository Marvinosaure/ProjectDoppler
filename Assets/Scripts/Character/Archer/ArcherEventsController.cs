using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEventsController : MonoBehaviour
{
    private ArcherAnimatorController _ArcherAnimator;

    private void Start()
    {
        _ArcherAnimator = GetComponent<ArcherAnimatorController>();
    }

    private void Update()
    {
        MouseEvents();
    }

    private void AnimationWeakAttack()
    {
        _ArcherAnimator.WeaksAttacks();
    }

    private void MouseEvents()
    {
        if (transform.tag == "Player Character")
        {
            if(Input.GetMouseButtonDown(0))
            {
                AnimationWeakAttack();
            }
        }
    }
}
