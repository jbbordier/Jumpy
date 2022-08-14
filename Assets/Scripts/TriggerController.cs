using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameManager GameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            GameManager.MoveGoal();
        }
    }
}
