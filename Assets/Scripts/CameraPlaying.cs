using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaying : MonoBehaviour
{
    Camera main;
    Vector3 placement;
   public GameManager gameManager;
    void Start()
    {
        main = Camera.main;
        placement = new Vector3(5, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameState.Playing)
        {
            main.transform.position = transform.position + placement;
            main.transform.LookAt(transform);
        }   
    }
}
