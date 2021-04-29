using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static bool isDed = false;

    public Transform forwardPoint;
    public Transform backwardPoint;
    public Transform rightPoint;
    public Transform leftPoint;

    private CharacterController pawn;

    Quaternion startingRotation;

    public float walkSpeed = 1.8f;

    public Transform cameraRig;

    public static float isRun = 1;

    public Transform cam;

    public static bool moving;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
        startingRotation = transform.localRotation;
    }

    void Update()
    {
        if (!isDed)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                moving = true;
            }
            else
            {
                moving = false;
            }


            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                isRun = 2.5f;
            }
            else
            {
                isRun = 1f;
            }

            //float v = Input.GetAxis("Vertical");


            if (!PlayerHandAnimator.attacking)
            {
                float singleStep = 20 * Time.deltaTime;
                if (Input.GetKey(KeyCode.W))
                {
                    rotatePlayer(1);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rotatePlayer(2);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rotatePlayer(3);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rotatePlayer(4);
                }
            }
            else
            {
                rotatePlayer(1);
            }


            if (moving && !PlayerHandAnimator.attacking)
            {
                pawn.SimpleMove(transform.forward * walkSpeed * isRun);
            }
        }
        else
        {
            Quaternion targetRot = startingRotation;
            targetRot.x += .8f;
            transform.localRotation = AnimMath.Lerp(transform.localRotation, targetRot, .08f);
        }
               
    }


    void rotatePlayer(int input)
    {
        Transform direction = this.transform;
        switch (input)
        {
            case 1:
                direction  = forwardPoint;
                break;
            case 2:
                direction = backwardPoint;
                break;
            case 3:
                direction = leftPoint;
                break;
            case 4:
                direction = rightPoint;
                break;
        }

        Vector3 targetDir = direction.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 20 * Time.deltaTime, 0f);

        Quaternion newestDir = Quaternion.LookRotation(newDir);

        newestDir.x = 0;
        newestDir.z = 0;

        transform.rotation = newestDir;
    }

}