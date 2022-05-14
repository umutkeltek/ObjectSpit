using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSprint : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ParticleSystem _smokeSystem;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _bulletSpeed = 12;
    
    [SerializeField] private float _torque = 120;
    [SerializeField] private float _maxTorqueBonus = 150;
    [SerializeField] private float _maxAngularVelocity = 10;
    private Rigidbody _rb;
    
    [SerializeField] private float _maxY = 10;
    [SerializeField] private float _maxUpAssist = 30;
    [SerializeField] private float _forceAmount = 600;
    private void Awake() => _rb = GetComponent<Rigidbody>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   var hitsTarget = Physics.Raycast(_spawnPoint.position, _spawnPoint.forward, float.PositiveInfinity, _targetLayer);
            
            
            var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            bullet.Init(_spawnPoint.forward * _bulletSpeed,hitsTarget);
            
            var assistPoint = Mathf.InverseLerp(0, _maxY, _rb.position.y);
            var assistAmount = Mathf.Lerp(_maxUpAssist, 0, assistPoint);
            var forceDir = -transform.forward * _forceAmount + Vector3.up * assistAmount;
            if (_rb.position.y > _maxY) forceDir.y = Mathf.Min(0, forceDir.y);
            _rb.AddForce(forceDir);
            
            var angularPoint = Mathf.InverseLerp(0, _maxAngularVelocity, Mathf.Abs(_rb.angularVelocity.z));
            var amount = Mathf.Lerp(0, _maxTorqueBonus, angularPoint);
            var torque = _torque + amount;
            
            var dir = Vector3.Dot(_spawnPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
            _rb.AddTorque(dir * _torque);

        }
    }
}
