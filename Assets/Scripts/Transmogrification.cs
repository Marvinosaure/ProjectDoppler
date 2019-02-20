using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmogrification : MonoBehaviour
{
    private GameObject _menuTransmo;
    private GameObject _buttonTransmo;

    private List<GameObject> _listCharacters;
    public List<GameObject> ListCharacter
    {
        get { return _listCharacters; }
    }

    public void AddCharacter(GameObject character)
    {
        if (character.CompareTag("transforMut") && !CheckIfCharacterExist(character))
        {
            _listCharacters.Add(character);
            _buttonTransmo.GetComponent<ButtonTransmo>().CreateButton(character.name);
        }
    }

    public bool IsTransmo(GameObject character)
    {
        if (character.CompareTag("transforMut"))
            return true;
        else
            return false;
    }

    public GameObject ReturnCharacterById(int i)
    {
        if (i <= _listCharacters.Count)
            return _listCharacters[i];
        else
            return _listCharacters[0];
    }

    private void Start()
    {
        _listCharacters = new List<GameObject>();
        _buttonTransmo = GameObject.Find("MenuTransmogrification");
    }

    private bool CheckIfCharacterExist(GameObject character)
    {
        if(_listCharacters.Contains(character))        
            return true;        
        else
            return false;        
    }

    private void Awake()
    {
        _menuTransmo = GameObject.Find("MenuTransmogrification");       
    }
}
