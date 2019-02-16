using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{        
    [SerializeField] private int _rotationSpeed = 7;

    private int _speed = 8;

    private int _speedRun = 8;
    public int SpeedRun
    {
        get { return _speedRun; } // permet de lire la variable _speedRun quand on fait appel a la propriété SpeedRun
        set
        {
            _speedRun = value; // permet décrire dans la variable _speedRun quand on fait appel a la propriété SpeedRun
        }
    }

    private int _speedWalk = 3;
    public int SpeedWalk
    {
        get { return _speedWalk; }
        set
        {
            _speedWalk = value;
        }
    }

    private int _jumpForce = 200;
    public int JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    private float _deltaV = 0;   

    private bool _isRunning = true;
    public bool IsRunnig
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public void MoveForward() // pour déplacer le perso vers l'avant
    {        
        _deltaV = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * _speed * _deltaV * Time.fixedDeltaTime);
    }

    public void RotationLerp(Transform b) //pour faire une rotation du player en fonction de l'angle du transform passé en parametre (la caméra dans notre cas)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, b.rotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void RotationCharacter() // permet de faire une rotation en x du perso (j'utilise cette methode uniquement pour le mode first person)
    {
        transform.Rotate(Vector3.up * 200 * Input.GetAxis("Mouse X") * Time.fixedDeltaTime);
    }

    public void Jump() // saut
    {        
         GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce);        
    }

    public void InitSpeed(int speed)
    {
        _speed = speed;
    }
}