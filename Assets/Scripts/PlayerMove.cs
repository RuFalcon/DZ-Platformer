using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;
    [SerializeField] Transform _colliderTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
            } 
        }
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_grounded == false) 
        {
            speedMultiplier = 0.2f;
            if (_rb.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }

            if (_rb.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        
        _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (_grounded )
        {
            _rb.AddForce(-_rb.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                _grounded = true;
            }
        }    
    }
    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
