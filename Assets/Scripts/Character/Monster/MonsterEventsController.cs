using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEventsController : MonoBehaviour
{
    private MonsterAnimatorController _MonsterAnimator;

    private void Start()
    {
        _MonsterAnimator = GetComponent<MonsterAnimatorController>();
    }

    private void Update()
    {
        MouseEvents();
    }

    private void AnimationWeakAttack()
    {
        _MonsterAnimator.WeaksAttacks();
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