using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionTrigger : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TimeManager timeManager;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootCheck();
        }
    }

    void ShootCheck()
    {
        RaycastHit _hitInfo;

        if (Physics.Raycast(_spawnPoint.position,_spawnPoint.right,out _hitInfo))
        {
            if (_hitInfo.collider.CompareTag("Enemy") || _hitInfo.collider.CompareTag("Multiplier"))
            {
                timeManager.DoSlowMotion();
            }
        }
    }
}
