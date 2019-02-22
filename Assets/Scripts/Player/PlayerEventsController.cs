using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsController : MonoBehaviour
{
    private PlayerCamera _camera;
    private RayCaster _rayCaster;
    private Transmogrification _saveTransmogrification;
    private InitPlayerCharacter _initPlayerCharacter;
    private int _currentTransmo;
    private GameObject _buttonTransmo;

    private void Awake()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
        _rayCaster = GameObject.Find("Main Camera").GetComponent<RayCaster>();
        _saveTransmogrification = GetComponent<Transmogrification>();
        _initPlayerCharacter = GetComponent<InitPlayerCharacter>();
        _currentTransmo = 0;
        _buttonTransmo = GameObject.Find("MenuTransmogrification");
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
    }

    private void CaptureTransmogrification()
    {
        _rayCaster.GetInfosGameObject();

        if (Input.GetMouseButtonUp(0))
        {            
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