﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D rb;

    public bool autoJump = true;
    public float speed;
    public float thrust;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //moveX = Input.GetAxis("Horizontal");
        #if UNITY_STANDALONE_WIN || UNITY_EDITOR
        if (Input.GetKey(left))
        {
            move(-1);
        }
        else if (Input.GetKey(right))
        {
            move(1);
        }
        else
        {
            move(0);
        }
        if (Input.GetKeyDown(jump))
        {
            pjump();
        }
        #endif
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" && autoJump)
        {
            pjump();
        }
    }

    public void pjump()
    {
        rb.AddForce(Vector2.up * thrust);
    }

    public void move(int side)
    {
        moveX = side;
    }
}
