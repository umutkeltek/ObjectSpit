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
        else if (collision.gameObject.tag == "Multiplier")
        {   Multiplier ml = collision.gameObject.transform.root.gameObject.GetComponent<Multiplier>();
            LevelManager.Instance.EndLevel(ml.multiplyValue);
            GameManager.Instance.RestartLevel();
        }
    }

    public void MoveBullet(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}
