using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private int multiplyValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            LevelManager.Instance.EndLevel(multiplyValue);
            GameManager.Instance.NextLevel();
        }
        
    }
}
