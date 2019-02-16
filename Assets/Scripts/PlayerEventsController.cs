using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsController : MonoBehaviour
{
    private RayCaster _rayCaster;
    private Transmogrification _saveTransmogrification;
    private SwitchCharacter _switchCharacter;
    private InitPlayerCharacter _initPlayerCharacter;
    private int _currentTransmo;

    private void Awake()
    {
        _rayCaster = GetComponent<RayCaster>();
        _saveTransmogrification = GetComponent<Transmogrification>();
        _switchCharacter = GetComponent<SwitchCharacter>();
        _initPlayerCharacter = GetComponent<InitPlayerCharacter>();
        _currentTransmo = 0;
    }

    private void Start()
    {
        _initPlayerCharacter.NewCharacter(_initPlayerCharacter.PlayerCharacter);
        _saveTransmogrification.AddCharacter(_initPlayerCharacter.PlayerCharacter);
    }

    void Update()
    {
        CaptureTransmogrification();
        UpdatePositionPlayer();
        SwitchCharacter();

        if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            _currentTransmo = 0;
        }

        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            _currentTransmo = 1;
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            _currentTransmo = 2;
        }
    }

    private void CaptureTransmogrification()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rayCaster.GetInfosGameObject();
            _saveTransmogrification.AddCharacter(_rayCaster.Target);
            _currentTransmo = _saveTransmogrification.ListCharacter.Count - 1;
        }
    }

    private void SwitchCharacter()
    {
        if(Input.GetKeyUp(KeyCode.C) && _saveTransmogrification.ListCharacter.Count > 0)
        {
            _initPlayerCharacter.DestroyCharacter(_initPlayerCharacter.PlayerCharacter);
            _initPlayerCharacter.NewCharacter(_saveTransmogrification.ListCharacter[_currentTransmo]);
        }
    }

    private void UpdatePositionPlayer()
    {
        if (_initPlayerCharacter.PlayerCharacter == null) return;

        _initPlayerCharacter.PlayerCharacterPosition(new Vector3(
            _initPlayerCharacter.PlayerCharacter.transform.Find("PositionPlayer").transform.position.x,
            _initPlayerCharacter.PlayerCharacter.transform.Find("PositionPlayer").transform.position.y,
            _initPlayerCharacter.PlayerCharacter.transform.Find("PositionPlayer").transform.position.z
        ));

        _initPlayerCharacter.PlayerCharacterRotation(_initPlayerCharacter.PlayerCharacter.transform.rotation);
    }
}