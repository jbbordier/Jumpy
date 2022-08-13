using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Controls controls;
    public GameManager gameManager;


    void Awake()
    {
        controls = new Controls();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Playing.Attack.performed += Attack;
        controls.Playing.Pausing.performed += PausePlay;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (gameManager.IsHammerReady && gameManager.State==GameState.Playing)
        {
            gameManager.isHammerFire = true;
        }
    }

    private void PausePlay(InputAction.CallbackContext context)
    {
        if (gameManager)
        {
            if(gameManager.State == GameState.Playing)
            {
                gameManager.State = GameState.Pause;
            }
            else
            {
                gameManager.State = GameState.Playing;
            }
        }
    }
    // Update is called once per frame
 
    public void OnReturnToMainMenu()
    {
        gameManager.State = GameState.Menu;
    }

    public void OnStartBuildingPress()
    {
        gameManager.State = GameState.Building;
    }

    public void OnEnterArene()
    {
        gameManager.State = GameState.Playing;
    }


}
