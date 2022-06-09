using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSceneDie : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
