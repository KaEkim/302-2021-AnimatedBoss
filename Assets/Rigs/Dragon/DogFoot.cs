using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFoot : MonoBehaviour
{

    private Vector3 startingPos;

    public float stepOffset = 0;

    public float deathOffset;

    void Start()
    {
        startingPos = transform.localPosition;
    }

    void Update()
    {
        if (DogControl.dogState == 0)
        {
            Vector3 finalPos = startingPos;
            finalPos.z += 3 * deathOffset;
            finalPos.y += 1;

            transform.localPosition = AnimMath.Slide(transform.localPosition, finalPos, .1f);
        }
        else
        {
            //use state machine from dog control script to decide what to do
            if (!DogControl.attacking)
            {
                switch (DogControl.dogState)
                {
                    case 0:
                        AnimateDeath();
                        break;
                    case 1:
                        AnimateIdle();
                        break;
                    case 2:
                        AnimateWalk();
                        break;
                    case 3:
                        AnimateAttack();
                        break;
                }
            }
            if (DogControl.attacking)
            {
                AnimateAttack();
            }
        }

    }

    void AnimateAttack()
    {
        Vector3 finalPos = startingPos;
        finalPos.z += (Mathf.Sin(Time.time * 4 * 4 + stepOffset)) / 2.5f * 8;

        finalPos = AnimMath.Slide(transform.localPosition, finalPos, .08f);

        transform.localPosition = finalPos;
    }

    void AnimateWalk()
    {
        Vector3 finalPos = startingPos;
        finalPos.z += (Mathf.Sin(Time.time * 4 + stepOffset)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localPosition, finalPos, .01f);

        transform.localPosition = finalPos;
    }

    void AnimateIdle()
    { 
        Vector3 newLoc = AnimMath.Slide(transform.localPosition, startingPos, .01f);

        transform.localPosition = newLoc;
    }

    void AnimateDeath()
    {
        //print("dogIsDead");
    }


}
