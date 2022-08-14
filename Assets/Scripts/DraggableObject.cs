using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class DraggableObject : MonoBehaviour
{
    [SerializeField]
    InputAction mouseClick;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

}

