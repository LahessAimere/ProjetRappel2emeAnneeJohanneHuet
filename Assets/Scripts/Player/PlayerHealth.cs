using UnityEngine;

public class PlayerHealth : MonoBehaviour, ISerializable<CharacterDTO>
{
    private float _maxHealth = 100f;
    private float _currentHealth;

    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0f, _maxHealth);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void Deserialize(CharacterDTO dataTransferObject)
    {
        _currentHealth = dataTransferObject.Health;
    }

    public CharacterDTO Serialized()
    {
        return new CharacterDTO
        {
            Health = _currentHealth
        };
    }
}