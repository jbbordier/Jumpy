using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstaclesTest : MonoBehaviour
{
    Vector3 initialPos;
    Vector3 GoalPos;
    void Start()
    {
        initialPos = transform.position;
        GoalPos = transform.position + Vector3.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == initialPos)
        {
            StartCoroutine(MoveObject(transform, GoalPos, 2f));
        }else if(transform.position == GoalPos)
        {
            StartCoroutine(MoveObject(transform, initialPos, 2f));
        }
    }

    IEnumerator MoveObject(Transform source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            source.position = Vector3.Lerp(source.position, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        source.position = target;
    }
}
