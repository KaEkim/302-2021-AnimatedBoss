using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianMovement : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Vertical");
        anim.SetFloat("CurrSpeed", speed);
        
        transform.position += transform.forward * speed * Time.deltaTime * 3;
    }
}
