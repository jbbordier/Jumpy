using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Controls controls;
    public GameManager gameManager;
    public GameObject pauseMenu;

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
        if (gameManager.IsHammerReady && gameManager.state==GameState.Playing)
        {
            gameManager.isHammerFire = true;
        }
    }

    private void PausePlay(InputAction.CallbackContext context)
    {
        if (gameManager)
        {
            if(gameManager.state == GameState.Playing)
            {
                gameManager.state = GameState.Pause;
                pauseMenu.SetActive(true);
            }
            else
            {
                gameManager.state = GameState.Playing;
                pauseMenu.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
