using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAnimator : MonoBehaviour
{
    
    private Vector3 startingPos;
    private Quaternion startingRot;

    GoonController goon;

    private Vector3 targetPos;
    private Quaternion targetRot;

    //changes sin wave so the feet dont move together (radii)
    public float stepOffset = 0;

    void Start()
    {
        startingPos = transform.localPosition;
        startingRot = transform.localRotation;

        goon = GetComponentInParent<GoonController>();


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

        //transform.position = AnimMath.Slide(transform.position, targetPos, .01f);
        //transform.rotation = AnimMath.Slide(transform.position, targetRot, .01);
    }

    void AnimateWalk()
    {
        Vector3 finalPos = startingPos;

        float time = Time.time * goon.stepSpeed + stepOffset;

        float frontToBack = (Mathf.Sin(time)) * goon.walkScale.z;

        finalPos += goon.moveDir * frontToBack * goon.walkScale.z;

        finalPos.y += (Mathf.Cos(time)) * goon.walkScale.y;

        bool isOnGround = (finalPos.y < startingPos.y);

        if (isOnGround)
        {
            finalPos.y = startingPos.y;
        }

        float p = 1 - Mathf.Abs(frontToBack);
        
        float anklePitch = isOnGround ? 0 :p * -10;

        transform.localPosition = finalPos;
        transform.localRotation = startingRot * Quaternion.Euler(0, 0, anklePitch);

        //targetRot = transform.parent.rotation * (startingRot * Quaternion.Euler(0, 0, anklePitch));

        //targetPos = transform.TransformPoint(finalPos);
        
    
    }

    void AnimateIdle()
    {
        transform.localPosition = startingPos;
        transform.localRotation = startingRot;

        //targetPos = transform.TransformPoint(startingPos);
        //targetRot = transform.parent.rotation * startingRot;

        FindGround();
    }

    void FindGround()
    {
        Ray ray = new Ray(transform.position + new Vector3(0,0.5f, 0), Vector3.down*2);

        if(Physics.Raycast(ray, out RaycastHit hit)){
            transform.position = hit.point;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            //targetPos = hit.point;

            //targetRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        else
        {

        }

    }

}