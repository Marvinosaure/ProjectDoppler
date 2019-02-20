using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListLocationsTransmos : MonoBehaviour
{
    private GameObject[] _locationsTransmos;
    public GameObject[] LocationsTransmos
    {
        get { return _locationsTransmos; }
    }

    private void Awake()
    {        
        _locationsTransmos = GameObject.FindGameObjectsWithTag("LocationsBtnTransmo");        
    }
}
