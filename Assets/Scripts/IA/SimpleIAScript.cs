using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleIAScript : MonoBehaviour
{
    [SerializeField] float _runDistance = 20f;    
    [SerializeField] float _securityDistance = 1f;

    private NavMeshAgent _agent;
    private Transform _target;
    private AnimatorController _animator;

    private void Start()
    {
        InitAI();
    }
    
    private void Update()
    {
        if (gameObject.tag == "Player Character") return;

        if(_agent.remainingDistance > _runDistance)
        {
            _agent.speed = 0;
            _animator.IdleAnimation();
        }
        else if(_agent.remainingDistance > _securityDistance)
        {
            _agent.speed = 3;
            _animator.RunAnimation();
        }
        else
        {
            _animator.IdleAnimation();
            _agent.speed = 0;
        }

        _agent.SetDestination(_target.position);
    }
    private void InitAI()
    {
        if (gameObject.tag == "Player Character") return;

        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Player").GetComponent<Transform>();
        _animator = GetComponent<AnimatorController>();
    }
}
