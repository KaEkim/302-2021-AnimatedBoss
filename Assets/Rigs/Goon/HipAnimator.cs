using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipAnimator : MonoBehaviour
{
    Quaternion startingRot;
    GoonController goon;

    private int rollAmount = 6;


    void Start()
    {

        goon = GetComponentInParent<GoonController>();
        startingRot = transform.localRotation;

    }

    void Update()
    {
        switch (goon.state)
        {
            case GoonController.States.Idle:
                AnimateIdle();
                break;
            case GoonController.States.Walk:
                AnimateWalk();
                break;
        }
    }

    void AnimateIdle()
    {
        transform.localRotation = startingRot;
    }

    void AnimateWalk()
    {
        
        float time = Time.time * goon.stepSpeed;
        float roll = Mathf.Sin(time) * rollAmount;

        transform.localRotation = Quaternion.Euler(0, 0, roll);
    }


}
