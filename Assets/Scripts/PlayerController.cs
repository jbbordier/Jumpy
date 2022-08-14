using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float mouseDragPhysicsSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;

    private Controls controls;
    public GameManager gameManager;
    private Camera mainCamera;
    private Vector3 velocity = Vector3.forward;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public GameObject choosenWeapon;


    void Awake()
    {
        controls = new Controls();
    }
    private void OnEnable()
    {
        controls.Enable();
        mainCamera = Camera.main;
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
        else if(gameManager.State == GameState.Building)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null && hit.collider.gameObject.GetComponent<DraggableObject>())
                {
                    StartCoroutine(DragUpdate(hit.collider.gameObject));
                }
            }
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
        choosenWeapon.transform.SetParent(GameObject.Find("Ecrou").transform);
        Vector3 sub = choosenWeapon.transform.position - choosenWeapon.transform.GetChild(0).position;
        choosenWeapon.transform.position = choosenWeapon.transform.parent.position + sub + new Vector3(0, 0.05f);
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while(controls.Playing.Attack.ReadValue<float>() != 0){
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (rb != null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.velocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                yield return null;
            }
        }
            
    }


}
