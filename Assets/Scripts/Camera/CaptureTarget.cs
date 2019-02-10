using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTarget : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private Transform _positionRay;
    private GameObject _currentTarget;
    

    private GameObject _character;
    public GameObject Character
    {
        get { return _character; }
        set
        {
            _character = value;
            InitPlayer();
        }
    }

    private void Awake()
    {
        Character = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(_character != null)
        {
            _ray = new Ray(_positionRay.position, transform.TransformDirection(Vector3.forward));

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                _currentTarget = GameObject.Find(_hit.collider.name);
            }

            Debug.DrawRay(_positionRay.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
        }
    }

    public void CreateCharacter()
    {
        if (_character == null) return;

        if (_currentTarget.CompareTag("transforMut") && _currentTarget.name != _character.name)
        {            
            _currentTarget = Instantiate
            (
                _currentTarget, 
                new Vector3(_character.transform.position.x, _currentTarget.transform.position.y, _character.transform.position.z), 
                _character.transform.rotation                
            );

            _currentTarget.tag = "Player";            

            Destroy(_character);
            Character = _currentTarget;
        }
    }

    private void InitPlayer()
    {
        _positionRay = _character.transform.Find("PositionCameraFP");

        _character.AddComponent<AnimatorController>();
        _character.AddComponent<CharacterController>();
        _character.AddComponent<CharacterEventsController>();
    }
}