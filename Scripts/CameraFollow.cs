using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private float damping = 2f;
    private float height = 5f;

    private Vector3 startPos;

    private bool canFollow;

   
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        canFollow = true;
    }

    
    void Update()
    {
        Follow();
    }
    void Follow()
    {
        if (canFollow)
        {
            transform.position = Vector3.Lerp
            (transform.position,new Vector3(player.position.x + 3.5f, player.position.y + height, player.position.z - 3.5f),
                Time.deltaTime * damping);
        }
    }
   public bool CANFOLLOW
   {
       get
       {
           return canFollow;
       }
       set
       {
           canFollow = value;
       }
   }
    
}
