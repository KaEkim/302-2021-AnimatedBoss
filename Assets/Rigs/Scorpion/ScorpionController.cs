using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    CharacterController pawn;

    public Transform groundRing;


    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");


        float h = Input.GetAxisRaw("Horizontal");


        Vector3 velocity = transform.forward * v + transform.right * h;
        //velocity.Normalize();

        pawn.SimpleMove(velocity * 5);

        //transform.Rotate( 0, h * 90 * Time.deltaTime, 0);

        //Vector3 localVelocity = groundRing.InverseTransformDirection(velocity);

        //groundRing.localPosition = AnimMath.Slide(groundRing.localPosition, localVelocity, .001f);

        //groundRing.localEulerAngles = new Vector3(0, h * 30, 0);



    }
}