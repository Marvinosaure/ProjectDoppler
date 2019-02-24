using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrutNavMeshAgent : MonoBehaviour
{
    [SerializeField] float _attackDistance = 1f;

    private NavMeshAgent _agent;
    private BrutAnimatorController _brutAnimator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _brutAnimator = GetComponent<BrutAnimatorController>();
    }
    
    private void Update()
    {
        if (gameObject.tag == "Player Character") return;

        if (_agent.remainingDistance < _attackDistance)
        {
            _agent.speed = 0;
            _brutAnimator.WeaksAttacks();
        }        
    }
}
