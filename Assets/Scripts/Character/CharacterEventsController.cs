using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventsController : MonoBehaviour
{
    private GameObject _cameraComponent; // ici je déclare une variable qui sera un game object (dans ce cas une camera)
    private AnimatorController _animatorController; //ici je déclare une Variable de type AnimatorController, pour avoir accès a toutes les methodes de la classe AnimatorController
    private CharacterController _characterController; //ici je déclare une Variable de type CharacterController, pour avoir accès a toutes les methodes de la classe CharacterController

    private void Awake()
    {
        _cameraComponent = GameObject.Find("Main Camera"); // ici j'affecte le game object main camera a la variable _cameraComponent pour avoir accès a tous ses components.
        _animatorController = GetComponent<AnimatorController>(); // Ici j'affecte le script AnimatorController a la variable _animatorController pour avoir accès a ses methodes.
        _characterController = GetComponent<CharacterController>(); // Ici j'affecte le script CharacterController a la variable _characterController pour avoir accès a ses methodes.
    }

    private void Update()
    {
        //Toutes ses methodes sont executées a chaque frame
        CharacterAnimationMoveForward();
        KeyboardEvents();        
    }

    private void FixedUpdate()
    {
        _characterController.MoveForward(); //ici j'appelle la methode moveForward de la classe CharacterController.

        if (_cameraComponent.GetComponent<PlayerCamera>().FPViewMode) // ici je test si la camera est en mode first person
        {
            _characterController.RotationCharacter(); //ici j'appelle la methode RotationCharacter de la classe CharacterController.
        }        
    }

    private void LateUpdate()
    {
        if (!_cameraComponent.GetComponent<PlayerCamera>().FPViewMode) // ici je test si la camera n'est pas en first person
        {
            CharacterControllerMoveRotation();            
        }
    }

    private void CharacterAnimationMoveForward() // cette methode sert à lancer les animations de course et de marche venant de la classe AnimatorController
    {
        if (Input.GetAxis("Vertical") > 0) // si l'axe verticale est supérieur a 0 on rentre dans la condition (l'axe change de valeur si on appui sur la touche Z ou fleche du haut) 
        {
            if (_characterController.IsRunnig) // si la propriété IsRunnig de la class CharacterController est vrai on rentre dans la condition
            {
                _animatorController.RunAnimation(); // on lance la methode RunAnimation de la classe Animator Controller
            }
            else
            {
                _animatorController.WalkAnimation(); // on lance la methode WalkAnimation de la classe Animator Controller
            }
        }
        else
        {
            _animatorController.IdleAnimation(); // on lance la methode IdleAnimation de la classe Animator Controller
        }
    }

    private void CharacterControllerMoveRotation() // cette methode fait appel a la methode RotationLerp de la classe CharacterController
    {
        if (Input.GetAxis("Vertical") > 0) // si l'axe vertical supérieur à 0 alors on rentre dans la condition      
            _characterController.RotationLerp(_cameraComponent.transform); // ici j'appel la methode RotationLerp de la class CharacterController
    }

    private void KeyboardEvents() // cette methode appel d'autres methodes en fonction de l'evenement clavier 
    {
        if (Input.GetKeyUp(KeyCode.CapsLock)) // au relachement de la touche "Caps lock" on lance la methode SwitchStateRun       
            SwitchStateRun();

        if (Input.GetKeyUp(KeyCode.Space)) // au relachement de la touche "Space" on lance la methode SwitchStateRun
            Jump();        
    }

    private void SwitchStateRun() //cette methode sert a changer le mode de course. soit mode course, soit mode marche
    {
        _characterController.IsRunnig = !_characterController.IsRunnig;

        if (_characterController.IsRunnig)
        {
            _characterController.InitSpeed(_characterController.SpeedRun);
        }
        else
        {
            _characterController.InitSpeed(_characterController.SpeedWalk);
        }
    }

    private void Jump() // pour sauter biatch
    {
        _characterController.Jump();
        _animatorController.JumpAnimation();
    }
}