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
        if (PlayerController.isDed)
        {
            transform.localPosition = AnimMath.Slide(transform.localPosition, startingPos, .01f);
        }
        else
        {
            if (!PlayerHandAnimator.attacking)
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
        }
    }

    void AnimateWalk()
    {
        Vector3 finalPos = startingPos;

        finalPos.z += (Mathf.Sin(Time.time * 4 * PlayerController.isRun + stepOffset)) / 2.5f * PlayerController.isRun;

        //Stops the rig from just jumping strait to where it wants
        finalPos = AnimMath.Slide(transform.localPosition, finalPos, .01f);

        transform.localPosition = finalPos;

    }

    void AnimateIdle()
    {
        
        //Stops the rig from just jumping strait to where it wants
        Vector3 newLoc = AnimMath.Slide(transform.localPosition, startingPos, .01f);
        
        transform.localPosition = newLoc;

    }

}