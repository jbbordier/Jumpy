using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameManager GameManager;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.name.Contains("Goal")&&GameManager.State == GameState.Playing)
        {
            GameManager.MoveGoal();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.name.Contains("Goal") && GameManager.State == GameState.Playing)
        {
            GameManager.MoveGoal();
            GameManager.MoveWall();
        }
    }
}
