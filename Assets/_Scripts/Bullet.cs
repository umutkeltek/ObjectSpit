using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float bulletDestroyTime = 0.5f ;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(this.gameObject,  bulletDestroyTime);
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
            GameManager.Instance.NextLevel();
        }
    }

    public void MoveBullet(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}
