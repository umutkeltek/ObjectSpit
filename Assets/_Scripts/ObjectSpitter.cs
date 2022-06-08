using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpitter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private float _bulletSpeed = 12;
    [SerializeField] private float _maxAngularVelocity = 10;
    
    [SerializeField] private float _torque = 120;
    [SerializeField] private float _maxTorqueBonus = 150;
    
    [SerializeField] private float _maxY = 10;
    [SerializeField] private float _maxUpAssist = 30;
    [SerializeField] private float _forceAmount = 600;
    
    private Rigidbody _rigidbody;
    AudioSource sound;
    private Transform _transform;
    
    private void Awake()
    {   
        _rigidbody = GetComponent<Rigidbody>();
        sound = gameObject.GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
        
    }

    private void Update()
    {
        _rigidbody.angularVelocity = new Vector3(0, 0,
            Mathf.Clamp(_rigidbody.angularVelocity.z, -_maxAngularVelocity, _maxAngularVelocity)); // Math.Clamp helps to limit angular velocity.
        if (Input.GetMouseButtonDown(0))
        {   
            SpawnBullet();
            ApplyForceTorque();
            
            
            
        }
    }

    private void SpawnBullet()
    {   sound.Play();
        var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        bullet.MoveBullet(_spawnPoint.right*_bulletSpeed);
    }

    private void ApplyForceTorque()
    {
        var assistPoint = Mathf.InverseLerp(0, _maxY, _rigidbody.position.y);
        var assistAmount = Mathf.Lerp(_maxUpAssist, 0, assistPoint);
        var forceDir = -transform.right * _forceAmount + Vector3.up * assistAmount;
        if (_rigidbody.position.y > _maxY) forceDir.y = Mathf.Min(0, forceDir.y);
        _rigidbody.AddForce(forceDir,ForceMode.Impulse);
        //_rigidbody.AddForceAtPosition((transform.right * forceMultiplier), forcePoint.position, ForceMode.Impulse);

        
        var angularPoint = Mathf.InverseLerp(0, _maxAngularVelocity, Mathf.Abs(_rigidbody.angularVelocity.z));
        var amount = Mathf.Lerp(0, _maxTorqueBonus, angularPoint);
        var torque = _torque + amount;
        
        var dir = Vector3.Dot(_spawnPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
        _rigidbody.AddTorque(dir * torque);
    }

    
}
