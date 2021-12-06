using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cameraFollow;

    [SerializeField] private GameObject blodFx;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDied)
        {
            if (rb.velocity.y <-20f)
            {
                playerDied = true;
                cameraFollow.CANFOLLOW = false;
                Debug.Log("улетел игрок");
                SoundManger.instance.GameEndSound();
                GamePlayControler.instance.RestartGame();
            }
        }
    }//

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            
            other.gameObject.SetActive(false);
            SoundManger.instance.PickedUpCoin();
            GamePlayControler.instance.IncrementScore();
            
        }
        if (other.tag == "SuperCoin")
        {
            
            other.gameObject.SetActive(false);
            SoundManger.instance.PickedUpCoin();
            GamePlayControler.instance.SuperIncrement();
            
        }

        if (other.tag == "Spike")
        {
            GameObject blfx = Instantiate(blodFx,other.transform.position,Quaternion.identity);
            blfx.SetActive(true);
            cameraFollow.CANFOLLOW = false;
            gameObject.SetActive(false);
            Debug.Log("Прекращаю следить");
            SoundManger.instance.GameEndSound();
            GamePlayControler.instance.RestartGame();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EndPlatform")
        {
            SoundManger.instance.GameStartSound();
            //по новой
        }
    }
}
