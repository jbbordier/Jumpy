using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaying : MonoBehaviour
{
    Camera main;
    Vector3 placement;
    void Start()
    {
        main = Camera.main;
        placement = new Vector3(5, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        main.transform.position = transform.position + placement;
        main.transform.LookAt(transform);
    }
}
