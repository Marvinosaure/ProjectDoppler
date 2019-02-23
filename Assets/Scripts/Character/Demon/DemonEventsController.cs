using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEventsController : MonoBehaviour
{
    private DemonAnimatorController _DemonAnimator;

    private void Start()
    {
        _DemonAnimator = GetComponent<DemonAnimatorController>();
    }

    private void Update()
    {
        MouseEvents();
    }

    private void AnimationWeakAttack()
    {
        _DemonAnimator.WeaksAttacks();
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
