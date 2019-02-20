using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransmo : MonoBehaviour
{
    private InitPlayerCharacter _initPlayer;
    private ListLocationsTransmos _listLocation;
    private SimpleButton _simpleButton;

    private List<GameObject> _buttonsList;
    public List<GameObject> ButtonList
    {
        get { return _buttonsList; }
    }

    public void CreateButton(string name)
    {
        if (LocationAvailable())
        {            
            float x = _listLocation.LocationsTransmos[_buttonsList.Count].GetComponent<RectTransform>().sizeDelta.x;
            float y = _listLocation.LocationsTransmos[_buttonsList.Count].GetComponent<RectTransform>().sizeDelta.y;
            GameObject character = GameObject.Find(name);

            _buttonsList.Add(_simpleButton.CreateButton(transform, _listLocation.LocationsTransmos[_buttonsList.Count].GetComponent<RectTransform>().localPosition, name));
            _buttonsList[_buttonsList.Count - 1].GetComponent<Button>().onClick.AddListener(() => SwitchCharacter(character));  
        }
    }    

    private void Start()
    {
        _listLocation = GetComponent<ListLocationsTransmos>();
        _simpleButton = GetComponent<SimpleButton>();
        _buttonsList = new List<GameObject>();
        _initPlayer = GameObject.Find("Player").GetComponent<InitPlayerCharacter>();
    }    

    private bool LocationAvailable()
    {
        if(_buttonsList.Count >= _listLocation.LocationsTransmos.Length) return false;
        else return true;        
    }

    private void SwitchCharacter(GameObject character)
    {
        _initPlayer.DestroyCharacter(_initPlayer.PlayerCharacter);
        _initPlayer.NewCharacter(character);
    }
}