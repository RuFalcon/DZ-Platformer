using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSecond : MonoBehaviour
{
    [SerializeField] private float _period = 7f;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName = "Attack";
    private float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if ( _timer > _period )
        {
            _timer = 0;
            _animator.SetTrigger(_triggerName);
        }
    }
}
