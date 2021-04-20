using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform forwardPoint;
    public Transform backwardPoint;
    public Transform rightPoint;
    public Transform leftPoint;

    private CharacterController pawn;

    public float walkSpeed = 1.8f;

    public Transform cameraRig;

    public static float isRun = 1;

    public Transform cam;

    public static bool moving;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
    }

    void Update()
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

        float v = Input.GetAxis("Vertical");
        //float h = Input.GetAxis("Horizontal");

        //if (v > 0)// || h != 0)
        //{
         //   Quaternion newRot = Quaternion.Lerp(transform.rotation, cameraRig.transform.rotation, .02f * isRun);
          //  newRot.x = 0;
           // newRot.z = 0;
           // transform.rotation = newRot;

        //}

        if (Input.GetKey(KeyCode.W))
        {
            float singleStep = 20 * Time.deltaTime;
            Vector3 targetDir = forwardPoint.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, .0f);

            Quaternion newestDir = Quaternion.LookRotation(newDir);

            newestDir.x = 0;
            newestDir.z = 0;

            transform.rotation = newestDir;
        }

        if (Input.GetKey(KeyCode.S))
        {
            float singleStep = 20 * Time.deltaTime;
            Vector3 targetDir = backwardPoint.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, .0f);

            Quaternion newestDir = Quaternion.LookRotation(newDir);

            newestDir.x = 0;
            newestDir.z = 0;

            transform.rotation = newestDir;
        }

        if (Input.GetKey(KeyCode.A))
        {
            float singleStep = 20 * Time.deltaTime;
            Vector3 targetDir = leftPoint.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, .0f);

            Quaternion newestDir = Quaternion.LookRotation(newDir);

            newestDir.x = 0;
            newestDir.z = 0;

            transform.rotation = newestDir;
        }

        if (Input.GetKey(KeyCode.D))
        {
            float singleStep = 20 * Time.deltaTime;
            Vector3 targetDir = rightPoint.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, .0f);

            Quaternion newestDir = Quaternion.LookRotation(newDir);

            newestDir.x = 0;
            newestDir.z = 0;

            transform.rotation = newestDir;
        }



        //if (Input.GetKey(KeyCode.D))
        //{
         //   transform.Rotate(0, 2, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
         //   transform.Rotate(0, -2, 0);
        //}

        

        if (moving)
        {
            pawn.SimpleMove(transform.forward * walkSpeed * isRun);
        }


    }
}
