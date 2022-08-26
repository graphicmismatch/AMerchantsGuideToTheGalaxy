using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed*Time.deltaTime, vertical * runSpeed* Time.deltaTime);
        anim.SetFloat("xv", horizontal);
        anim.SetFloat("yv", vertical);
        anim.SetFloat("v",Mathf.Abs(horizontal*10) + Mathf.Abs(vertical*10));
    }
}
