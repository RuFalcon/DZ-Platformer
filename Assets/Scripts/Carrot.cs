using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    void Start()
    {
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rb.velocity = toPlayer * _speed;
    }
}
