using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Debug.Log("вошел");
            Destroy(other.gameObject);
        }
    }
}
