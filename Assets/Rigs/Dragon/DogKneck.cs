using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKneck : MonoBehaviour
{
    public float rotAmount;
    public bool wrongKneck;
    private Quaternion startingPos;

    void Start()
    {

        startingPos = transform.localRotation;

    }

    void Update()
    {
        if (DogControl.attacking && wrongKneck)
        {
            AnimateAttack();
        }
        if (!wrongKneck)
        {
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
                }
            }
            else
            {
                AnimateAttack1();
            }
        }
    }

    void AnimateDeath()
    {

    }

    void AnimateIdle()
    { 
        Quaternion finalPos = startingPos;

        finalPos.y += (Mathf.Sin(Time.time / 4)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);

        transform.localRotation = finalPos;
    }

    void AnimateWalk()
    {
        Quaternion jumpLerp = AnimMath.Slide(transform.localRotation, startingPos, .003f);
        transform.localRotation = jumpLerp;
    }

    void AnimateAttack()
    {
        Quaternion finalPos = new Quaternion(startingPos.x + rotAmount, startingPos.y, startingPos.z, startingPos.w);
        
        transform.localRotation = AnimMath.Slide(transform.localRotation, finalPos, .03f);
    }

    void AnimateAttack1()
    {
        Quaternion finalPos = startingPos;

        finalPos.y += (Mathf.Sin(Time.time * 12)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);

        transform.localRotation = finalPos;
    }
}