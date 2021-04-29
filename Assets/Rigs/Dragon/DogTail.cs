using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTail : MonoBehaviour
{

    Quaternion startingPos;

    void Start()
    {
        startingPos = transform.localRotation;
        
    }

    void Update()
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
                    AnimateIdle();
                    break;
            }
        }
        else
        {
            AnimateAttack();
        }
    }

    void AnimateDeath()
    {

    }

    void AnimateIdle()
    {
        Quaternion finalPos = startingPos;

        finalPos.y += (Mathf.Sin(Time.time / 4 + 3.14f)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);

        transform.localRotation = finalPos;
    }

    void AnimateAttack()
    {
        Quaternion finalPos = new Quaternion(startingPos.x + -1.3f, startingPos.y, startingPos.z, startingPos.w);

        transform.localRotation = AnimMath.Slide(transform.localRotation, finalPos, .08f);

    }
}
