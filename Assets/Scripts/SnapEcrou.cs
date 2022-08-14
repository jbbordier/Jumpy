using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapEcrou : MonoBehaviour
{
    public PlayerController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Goundoum")
        {
            if (controller.choosenWeapon == null)
            {
                controller.choosenWeapon = other.gameObject;
            }
            if (other.gameObject.GetComponent<DraggableObject>())
            {
                if (controller.choosenWeapon == other.gameObject)
                {
                    Vector3 sub = other.transform.position - other.transform.GetChild(0).position;
                    other.transform.position = transform.position + sub + new Vector3(0, 0.05f);
                    controller.StopAllCoroutines();
                }
                else
                {
                    controller.choosenWeapon.transform.position = controller.choosenWeapon.transform.position + Vector3.left * 1.5f + Vector3.up;
                    Vector3 sub = other.transform.position - other.transform.GetChild(0).position;
                    other.transform.position = transform.position + sub + new Vector3(0, 0.05f);
                    controller.StopAllCoroutines();
                    controller.choosenWeapon = other.gameObject;
                }
            }
        }
    }

}
