using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameManager GameManager;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "pCube2":
                GameManager.GoundoumHP -= 10;
                break;
            case "pCylinder1":
                GameManager.GoundoumHP -= 20;
                break;
            case "Arme":
                GameManager.RoumbotHP -= 20;
                break;
            case "BrasD":
                GameManager.RoumbotHP -= 5;
                break;
            case "Main":
                GameManager.RoumbotHP -= 10;
                break;
            case "Tronconeuse":
                GameManager.RoumbotHP -= -25;
                break;
            default:
                break;
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
