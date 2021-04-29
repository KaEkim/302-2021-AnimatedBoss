using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    void Start()
    {
        


    }

    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * 4);

    }
}
