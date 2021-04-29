using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    Quaternion startingPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startingPos = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDed)
        {
            Quaternion goToLoc = startingPos;

            goToLoc.x -= 1.3f;

            transform.localRotation = AnimMath.Slide(transform.localRotation, goToLoc, .01f);

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
            if (PlayerHandAnimator.attacking)
            {
                jumpBack();
            }
        }
    }

    void AnimateWalk()
    {
        Quaternion finalPos = startingPos;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);
        transform.localRotation = startingPos;

    }

    void AnimateIdle()
    {
        Quaternion finalPos = startingPos;

        finalPos.y += (Mathf.Sin(Time.time / 4)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);

        transform.localRotation = finalPos;
        //Vector3 finalPos = startingPos;

        //finalPos.y += (Mathf.Sin(Time.time * 4 + stepOffset)) / 2.5f;

        //transform.localPosition = finalPos;
    }

    void jumpBack()
    {
        Quaternion jumpLerp = AnimMath.Slide(transform.localRotation, startingPos, .003f);
        transform.localRotation = jumpLerp;
    }
}