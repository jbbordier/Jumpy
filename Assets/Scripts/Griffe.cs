using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griffe : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 GoalRotation;
    public AnimationCurve curveDescente;
    public AnimationCurve curveMontee;
    private Vector3 previousRotation;
    AnimationCurve _curve;
    public float speed = 0.5f;
    bool flow = true;
    private float _current, _target;
    private Vector3 initialRotation;
    float angle = 70f;

    void Start()
    {
        GoalRotation = new Vector3(transform.parent.transform.rotation.eulerAngles.x+ angle, transform.parent.transform.rotation.eulerAngles.y, transform.parent.transform.rotation.eulerAngles.z);
        initialRotation = new Vector3(GoalRotation.x , GoalRotation.y, GoalRotation.z);
        previousRotation = Quaternion.identity.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameState.Playing)
        {
            GoalRotation = new Vector3(transform.parent.transform.rotation.eulerAngles.x +angle, transform.parent.transform.rotation.eulerAngles.y, transform.parent.transform.rotation.eulerAngles.z);
            initialRotation = new Vector3(GoalRotation.x-angle, GoalRotation.y, GoalRotation.z);
            if (_current == 0)
            {
                _target = 1;
                _curve = curveDescente;
            }
            if (_current == 1)
            {
                _target = 0;
                _curve = curveMontee;
            }
            _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(initialRotation), Quaternion.Euler(GoalRotation), _curve.Evaluate(_current));
        }
    }
}
