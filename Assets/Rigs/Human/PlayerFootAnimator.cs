using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootAnimator : MonoBehaviour
{

    private Vector3 startingPos;

    public float stepOffset = 0;

    void Start()
    {
        startingPos = transform.localPosition;
    }

    
    void Update()
    {
        if (PlayerController.moving)
        {
            AnimateWalk();
        }
        else
        {
            AnimateIdle();
        }
    }

    void AnimateWalk()
    {
        Vector3 finalPos = startingPos;

        finalPos.z += (Mathf.Sin(Time.time * 4 * PlayerController.isRun + stepOffset)) / 2.5f * PlayerController.isRun;

        transform.localPosition = finalPos;

    }
    
    void AnimateIdle()
    {


        transform.localPosition = startingPos;

    }

}