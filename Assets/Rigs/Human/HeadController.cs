using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    Quaternion startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localRotation;
    }

    // Update is called once per frame
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

        transform.localRotation = startingPos;

    }

    void AnimateIdle()
    {
        Quaternion finalPos = startingPos;

        finalPos.y += (Mathf.Sin(Time.time/4)) / 2.5f;

        finalPos = AnimMath.Slide(transform.localRotation, finalPos, .06f);

        transform.localRotation = finalPos;
        //Vector3 finalPos = startingPos;

        //finalPos.y += (Mathf.Sin(Time.time * 4 + stepOffset)) / 2.5f;

        //transform.localPosition = finalPos;

    }
}
