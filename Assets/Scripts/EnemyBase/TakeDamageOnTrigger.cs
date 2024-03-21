using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
