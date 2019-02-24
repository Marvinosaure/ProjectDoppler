using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStats : MonoBehaviour
{
    [SerializeField] private int _speedRun = 15;
    [SerializeField] private int _speedWalk = 3;
    [SerializeField] private int _jumpForce = 250;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        if (_characterController == null) return;

        _characterController.SpeedRun = _speedRun;
        _characterController.SpeedWalk = _speedWalk;
        _characterController.JumpForce = _jumpForce;

        if(_characterController.IsRunnig)
        {
            _characterController.InitSpeed(_speedRun);
        }
        else
        {
            _characterController.InitSpeed(_speedWalk);
        }
    }  
}
