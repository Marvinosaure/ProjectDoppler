using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{    
    [SerializeField] private int _rotationSpeed = 3;
    
    private Transform _positionCameraTP;
    private Transform _positionCameraFP;
    private Vector3 _offset;
    private GameObject _player;

    private bool _FPViewMode;
    public bool FPViewMode
    {
        get { return _FPViewMode; }
    }

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void Start()
    {
        InitCamera();        
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            transform.position = _positionCameraFP.position;
            _FPViewMode = true;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            transform.position = _positionCameraTP.position;
            _FPViewMode = false;
        }    
    }

    private void LateUpdate()
    {
        if(_player != null)
        {        
            if (!_FPViewMode)
            {                
                transform.position = _player.transform.position + _offset;

                Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up * Time.deltaTime);
                _offset = turnAngle * _offset;

                transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            }
            else
            {
                if (_positionCameraFP == null) InitCamera();

                transform.position = _positionCameraFP.position;
                transform.Rotate(Vector3.left * 200 * Time.deltaTime * Input.GetAxis("Mouse Y"));
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, _positionCameraFP.eulerAngles.y, transform.eulerAngles.z);        
            }
        }
    }

    public void InitCamera()
    {
        if (_player == null) return;

        _positionCameraTP = _player.transform.Find("PositionCameraTP").transform;
        _positionCameraFP = _player.transform.Find("PositionCameraFP").transform;
        transform.position = _positionCameraTP.position;
        _offset = transform.position - _player.transform.position;
        _FPViewMode = false;
    }

    public void SwitchViewMode()
    {
        if (_positionCameraFP == null || _positionCameraTP == null) InitCamera();        

        if(!_FPViewMode)
        {
            transform.position = _positionCameraFP.position;
            _FPViewMode = true;
        }
        else
        {
            transform.position = _positionCameraTP.position;
            _FPViewMode = false;
        }
    }
}