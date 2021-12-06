using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float movementForce = 0.5f;
    private float jumpForce = 0.5f;
    private float jumpTime = 0.15f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ForAndroid();
    }

    void GetInput()
    {//захерачить код для касания
        if (Input.GetKeyDown(KeyCode.A))
        {
            Jump(true);
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            Jump(false);
        }
    }

    void ForAndroid()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                Jump(true);
            }
            else
            {
                Jump(false);
            }
        }
        else
        {
           
        }
    }

    void Jump(bool left)
    {
        SoundManger.instance.JumpSound();
        if (left)
        {
            transform.DORotate(new Vector3(0f, 90, 0f), 0f);
            rb.DOJump(new Vector3
                (transform.position.x-movementForce,transform.position.y+jumpForce,transform.position.z),
                0.5f,1,jumpTime);
        }
        else
        {
            transform.DORotate(new Vector3(0f, -180f, 0f), 0f);
            rb.DOJump(new Vector3
                    (transform.position.x,transform.position.y+jumpForce,transform.position.z+movementForce),
                0.5f,1,jumpTime);
        }
    }
}
