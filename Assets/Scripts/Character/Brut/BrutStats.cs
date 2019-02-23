using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutStats : MonoBehaviour
{
    [SerializeField] private int _speedRun = 8;
    [SerializeField] private int _speedWalk = 3;
    [SerializeField] private int _jumpForce = 150;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        if (_characterController == null) return;

        _characterController.SpeedRun = _speedRun;
        _characterController.SpeedWalk = _speedWalk;
        _characterController.JumpForce = _jumpForce;

        if (_characterController.IsRunnig)
        {
            _characterController.InitSpeed(_speedRun);
        }
        else
        {
            _characterController.InitSpeed(_speedWalk);
        }
    }
}
