using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutEventsController : MonoBehaviour
{
    private BrutAnimatorController _brutAnimator;

    private void Start()
    {
        _brutAnimator = GetComponent<BrutAnimatorController>();
    }

    private void Update()
    {
        MouseEvents();
    }

    private void AnimationWeakAttack()
    {
        _brutAnimator.WeaksAttacks();
    }

    private void MouseEvents()
    {
        if(transform.tag == "Player Character")
        {
            if(Input.GetMouseButtonDown(0))
            {
                AnimationWeakAttack();
            }
        }
    }
}
