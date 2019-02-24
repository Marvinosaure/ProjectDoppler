using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinEventsController : MonoBehaviour
{
    private PaladinAnimatorController _PaladinAnimator;

    private void Start()
    {
        _PaladinAnimator = GetComponent<PaladinAnimatorController>();
    }

    private void Update()
    {
        MouseEvents();
    }

    private void AnimationWeakAttack()
    {
        _PaladinAnimator.WeaksAttacks();
    }

    private void MouseEvents()
    {
        if (transform.tag == "Player Character")
        {
            if (Input.GetMouseButtonDown(0))
            {
                AnimationWeakAttack();
            }
        }
    }
}

