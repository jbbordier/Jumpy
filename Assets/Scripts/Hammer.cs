using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Vector3 GoalRotation;
    public AnimationCurve curveDescente;
    public AnimationCurve curveMontee;
    AnimationCurve _curve;
    public float speed = 0.5f;
    bool flow = true;
    private float _current, _target;
    private Vector3 initialRotation;
    void Start()
    {
        GoalRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z+90);
        initialRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
      if(_current == 0)
        {
            _target = 1;
            _curve = curveDescente;
        }
        else if (_current == 1)
        {
            _target = 0;
            _curve = curveMontee;
        }
        Debug.Log(_current);
        _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(Quaternion.Euler(initialRotation), Quaternion.Euler(GoalRotation), _curve.Evaluate(_current));

    }
}
