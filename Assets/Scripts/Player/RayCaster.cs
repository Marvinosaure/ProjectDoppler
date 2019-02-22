using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    private GameObject _target;
    public GameObject Target
    {
        get { return _target; }
    }

    public void GetInfosGameObject()
    {        
        _ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))        
            _target = GameObject.Find(_hit.collider.name);        

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);        
    }
}