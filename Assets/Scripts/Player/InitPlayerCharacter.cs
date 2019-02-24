using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerCharacter : MonoBehaviour
{
    [SerializeField] GameObject _defaultCharacter;

    private GameObject _playerCharacter;
    public GameObject PlayerCharacter
    {
        get { return _playerCharacter; }
        set { _playerCharacter = value; }
    }

    public void NewCharacter(GameObject character)
    {
        character = Instantiate(
            character,
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            transform.rotation
        );

        character.tag = "Player Character";

        //character.AddComponent<AnimatorController>();
        character.AddComponent<CharacterController>();
        character.AddComponent<CharacterEventsController>();

        PlayerCharacter = character;
    }

    public void DestroyCharacter(GameObject character)
    {
        DestroyImmediate(character);
    }

    public void PlayerCharacterPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void PlayerCharacterRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    private void Awake()
    {
        PlayerCharacter = _defaultCharacter;
    }

}
