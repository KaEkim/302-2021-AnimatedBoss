using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogControl : MonoBehaviour
{

    //Code should be as follows

    //Control if dog is walking, idle, attacking, or dead
    //Look at the player
    //If player gets within x distance, lower head, and charge quickly in strait line past player

    public int dogHealth = 5;

    public Transform playerTarget;

    public static Transform playerTransform;


    public static int dogState = 1;

    public float speed;

    public static bool attacking;

    private int timer = 0;

    private CharacterController pawn;

    Vector3 deathLoc;


    void Start()
    {

        pawn = GetComponent<CharacterController>();
        playerTransform = playerTarget;

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, playerTarget.position) < 1.8f)
        {
            PlayerController.isDed = true;
        }

        if (dogState == 0)
        {
            pawn.enabled = false;
            print("dogDed");
            transform.position = AnimMath.Slide(transform.position, deathLoc, .1f);
        }

        if (attacking)
        {
            pawn.SimpleMove(transform.forward * speed * 2);
            timer++;
            if (timer > 300)
            {
                attacking = false;
                timer = 0;
            }
        }

        if (dogHealth < 1 && dogState != 0)
        {
            dogDeath();
            deathLoc = transform.position;
            deathLoc.y -= 1;
        }
        else if (dogHealth !< 1 && attacking == false) ;
        {
            if (!attacking)
            {
                if (Vector3.Distance(playerTarget.position, transform.position) < 5)
                {
                    dogAttack();
                    attacking = true;
                    timer = 0;
                }
                else if (Vector3.Distance(playerTarget.position, transform.position) < 10)
                {
                    dogWalk();
                    pawn.SimpleMove(transform.forward * speed);
                }
                else
                {
                    dogIdle();
                }

                Vector3 targetDir = DogControl.playerTransform.position - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 20 * Time.deltaTime, 0f);

                Quaternion newestDir = Quaternion.LookRotation(newDir);

                newestDir.x = 0;
                newestDir.z = 0;

                if (transform.rotation != newestDir)
                {
                    dogWalk();
                    transform.rotation = newestDir;
                }
            }
        }
    }

    void dogDeath()
    {

        dogState = 0;

    }

    void dogWalk()
    {

        dogState = 2;

    }

    void dogAttack()
    {

        dogState = 3;

    }

    void dogIdle()
    {

        dogState = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "project")
        {
            dogHealth -= 1;
        }
    }
}