using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 5;
    [SerializeField] private int _maxHealth = 8;
    //[SerializeField] private AudioSource _takeDamageSound;
    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] HealthUI _healthUI;
    //[SerializeField] DamageScreen _damageScreen;
    //[SerializeField] Blink _blink;
    [SerializeField] private UnityEvent _eventOnTakeDamage;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_playerHealth);
    }

    private bool _invulnerable = false;
    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _playerHealth -= damageValue;
            
            if (_playerHealth <= 0)
            {
                _playerHealth = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            //_takeDamageSound.Play();
            _healthUI.DisplayHealth(_playerHealth);
            //_damageScreen.StartEffect();
            //_blink.StartBlink();

            _eventOnTakeDamage.Invoke();
        } 
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _playerHealth += healthValue;
        
        if (_playerHealth > _maxHealth)
        {
            _playerHealth = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DisplayHealth(_playerHealth);
    }

    public void Die()
    {
        Debug.Log("You Loose");
    }
}
