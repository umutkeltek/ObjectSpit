using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyGoldValue = 200;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            LevelManager.Instance.AddTemporaryGold(enemyGoldValue);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
