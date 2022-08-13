using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveRobot : MonoBehaviour
{
    public GameObject goalPosition;

    public NavMeshAgent agent;
    public GameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameState.Playing)
        agent.SetDestination(goalPosition.transform.position);
    }
}
