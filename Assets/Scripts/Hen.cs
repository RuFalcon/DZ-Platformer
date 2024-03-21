using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    private Transform _playerTransform;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rb.mass * (toPlayer * _speed - _rb.velocity) / _timeToReachSpeed;
        _rb.AddForce(force);
    }
}
