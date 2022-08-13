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
    private bool _reinitFireHammer = false;

    public GameManager gameManager;
    void Start()
    {
        GoalRotation = new Vector3(transform.rotation.eulerAngles.x-90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        initialRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameState.Playing)
        {
            if (gameManager.isHammerFire)
            {
                if (_current == 0)
                {
                    gameManager.IsHammerReady = true;
                    _target = 1;
                    _curve = curveDescente;
                    if (_reinitFireHammer)
                    {
                        gameManager.isHammerFire = false;
                        _reinitFireHammer = false;
                    }
                }
                if (_current != 0)
                {
                    gameManager.IsHammerReady = false;
                }
                if (_current == 1)
                {
                    _target = 0;
                    _curve = curveMontee;
                    _reinitFireHammer = true;
                }
                _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(initialRotation), Quaternion.Euler(GoalRotation), _curve.Evaluate(_current));
            }
            
        }
    }
}
