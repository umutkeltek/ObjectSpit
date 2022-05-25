using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Multiplier" && collision.transform.tag != "Enemy" && collision.transform.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveBullet(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}
