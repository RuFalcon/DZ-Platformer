using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform _body;

    private float _rotationAngle;
    void LateUpdate()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;

        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if (toAim.x < 0)
        {
            _rotationAngle = Mathf.Lerp(_rotationAngle, 45f, Time.deltaTime * 7f);
        }
        else
        {
            _rotationAngle = Mathf.Lerp(_rotationAngle, -45f, Time.deltaTime * 7f);
        }

        _body.localEulerAngles = new Vector3(0, _rotationAngle, 0);
    }
}
