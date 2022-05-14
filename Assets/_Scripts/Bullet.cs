using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _trail;
    private Rigidbody _rb;
    private bool _hitsTarget;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    public void Init(Vector3 vel, bool hitsTarget) {
        _rb.velocity = vel;
        _hitsTarget = hitsTarget;
        if (_hitsTarget) _trail.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision) {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        if (_hitsTarget) {
            GameManager.Instance.ToggleSlowMo(false);
        }

        Destroy(gameObject);
    }

    
}