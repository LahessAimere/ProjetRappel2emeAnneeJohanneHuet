using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    
    public Action<float, float> OnHealthChanged;
    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
        
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
}