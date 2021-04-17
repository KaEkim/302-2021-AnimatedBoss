using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class StickyFoot : MonoBehaviour
{

    public static float moveThreshold = 2;

    public Transform stepPosition;

    private Vector3 plantedPosition;
    private Vector3 prevPlantedPosition;

    private Quaternion prevPlantedRotation = Quaternion.identity;
    private Quaternion plantedRotation = Quaternion.identity;

    public AnimationCurve verticalStepMovement;

    private float timeLength = .15f;
    private float timeCurrent = 0;

    Transform kneePole;

    // Start is called before the first frame update
    void Start()
    {
        kneePole = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {   
        if (CheckIfCanStep())
        {

            DoRaycast();

        }
        if(timeCurrent < timeLength)
        {

            timeCurrent += Time.deltaTime;

            float p = timeCurrent / timeLength;

            Vector3 finalPosition = AnimMath.Lerp(prevPlantedPosition, plantedPosition, p);

            finalPosition.y += verticalStepMovement.Evaluate(p);

            transform.position = finalPosition;

            transform.rotation = AnimMath.Lerp(prevPlantedRotation, plantedRotation, p);

            Vector3 vFromCenter = transform.position - transform.parent.position;

            vFromCenter.y = 0;

            vFromCenter.Normalize();
            vFromCenter.y += 2.5f;

            //kneePole.position = vFromCenter + transform.position;

        }
        else
        {
            transform.position = AnimMath.Slide(transform.position, plantedPosition, .001f);
            transform.rotation = plantedRotation;
        }

    }

    bool CheckIfCanStep()
    {

        if (timeCurrent < timeLength) return false;
        Vector3 vBetween = transform.position - stepPosition.position;
        
        return (vBetween.sqrMagnitude > moveThreshold * moveThreshold);

    }


    void DoRaycast()
    {
        Ray ray = new Ray(stepPosition.position + Vector3.up, Vector3.down);

        Debug.DrawRay(ray.origin, ray.direction * 3);

        if(Physics.Raycast(ray, out RaycastHit hit, 3))
        {

            prevPlantedPosition = transform.position;
            prevPlantedRotation = transform.rotation;

            timeCurrent = 0;

            plantedPosition = hit.point;
            plantedRotation = Quaternion.FromToRotation(transform.up, hit.normal);// transform.rotation;
      
        }
    }
}