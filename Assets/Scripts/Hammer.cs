using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject hammer;
    public Quaternion initRotation;
    void Start()
    {
        initRotation = hammer.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
