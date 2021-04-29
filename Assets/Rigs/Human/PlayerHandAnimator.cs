using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandAnimator : MonoBehaviour
{
    public float handRotWhileAiming;

    public float handAimX;
    public float handAimY;
    public float handAimZ;

    public Transform parent;
    public Transform camRig;

    private Vector3 startingPos;
    private Quaternion startingRot;

    public float stepOffset = 0;

    public Transform attackLoc;

    public static bool attacking;

    public GameObject attackObject;


    void Start()
    {
        startingPos = transform.localPosition;

        startingRot = transform.localRotation;
    }

    void Update()
    {
        if (PlayerController.isDed)
        {
            Vector3 goTo = startingPos;
            goTo.y += 4;

            transform.localPosition = AnimMath.Slide(transform.localPosition, goTo, .01f);

        }
        else
        {


            if (Input.GetMouseButton(0))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Instantiate(attackObject, transform.position, camRig.rotation);
                }
                attacking = true;
                //print(Vector3.Distance(transform.localPosition, attackLoc.localPosition));
                

                if (Vector3.Distance(transform.localPosition, attackLoc.localPosition) > .2f)
                {
                    transform.localPosition = AnimMath.Slide(transform.localPosition, attackLoc.localPosition, .01f);

                    //create variable to hold and adjust local rotation while aiming
                    Quaternion localRot = startingRot;


                    localRot.y += handAimY;
                    localRot.x += handAimX;
                    localRot.z += handAimZ;

                    transform.localRotation = localRot;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                attacking = false;
                transform.localRotation = startingRot;
            }

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

    void AnimateWalk()
    {
        if (!attacking)
        {
            Vector3 finalPos = startingPos;

            finalPos.z += (Mathf.Sin(Time.time * 4 * PlayerController.isRun + stepOffset)) / 6f * PlayerController.isRun;

            //Stops the rig from just jumping strait to where it wants
            finalPos = AnimMath.Slide(transform.localPosition, finalPos, .01f);

            transform.localPosition = finalPos;
        }
    }

    void AnimateIdle()
    {
        if (!attacking)
        {

            //Stops the rig from just jumping strait to where it wants
            Vector3 newLoc = AnimMath.Slide(transform.localPosition, startingPos, .01f);

            transform.localPosition = newLoc;
        
        }
    }
}
