using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandAnimator : MonoBehaviour
{

    private Vector3 startingPos;

    public float stepOffset = 0;

    public Transform attackLoc;

    private bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            attacking = true;

            transform.localPosition = AnimMath.Slide(transform.localPosition, attackLoc.localPosition, .01f);
            
            //must change z axis to rotate to 180
            
        }
        if (Input.GetMouseButtonUp(0)){
            attacking = false;
        }

        if (PlayerController.moving)
        {
            AnimateWalk();
        }else
        {
            AnimateIdle();
        }

    }

    void AnimateWalk()
    {
        if (!attacking)
        {
            Vector3 finalPos = startingPos;

            finalPos.z += (Mathf.Sin(Time.time * 4 * PlayerController.isRun + stepOffset)) / 6f * PlayerController.isRun;

            transform.localPosition = finalPos;
        }

    }

    void AnimateIdle()
    {
        if (!attacking)
        {
            transform.localPosition = startingPos;
        }
    }


}
