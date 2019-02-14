using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTransmogrification : MonoBehaviour
{
    private List<GameObject> _listCharacters;
    public List<GameObject> ListCharacter
    {
        get { return _listCharacters; }
    }

    public void AddCharacter(GameObject character)
    {
        if (character.CompareTag("transforMut") && !CheckIfCharacterExist(character))
            _listCharacters.Add(character);
    }

    public GameObject ReturnCharacterById(int i)
    {
        if(i <= _listCharacters.Count)
            return _listCharacters[i];
        else
            return _listCharacters[0];
    }

    private void Start()
    {
        _listCharacters = new List<GameObject>();
    }

    private bool CheckIfCharacterExist(GameObject character)
    {
        if(_listCharacters.Contains(character))        
            return true;        
        else
            return false;        
    }
}
