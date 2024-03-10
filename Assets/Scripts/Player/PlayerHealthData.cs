using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new_PlayerHealthData", menuName = "ScriptableObjects/new PlayerHealthData")]
public class PlayerHealthData : ScriptableObject
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    
    public Action<float, float> OnHealthChanged;
    
    public float CurrentHealth
    {
        get => _currentHealth;
        set 
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
    
    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }
}