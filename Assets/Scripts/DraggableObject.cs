using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DraggableObject : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        if (gameManager.State == GameState.Building || gameManager.State == GameState.Playing)
        {
            gameObject.SetActive(true);
        }
    }
}

