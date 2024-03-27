using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _startFixedDeltaTime;
    [SerializeField] private float _timeScale = 0.3f;
    void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = _timeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        _startFixedDeltaTime = 0.02f * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
