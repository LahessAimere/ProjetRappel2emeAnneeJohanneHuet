using UnityEngine;

public class PlayerInteractPowerUp : MonoBehaviour
{
    [Header("Actions Prefab")]
    [SerializeField] private ShieldBehavior _shieldPrefab;

    [SerializeField] private PlayerHealth _playerHealth;
    
    [Header("Scriptable Objects")]
    [SerializeField] private ItemData _itemShield;
    [SerializeField] private ItemData _itemRepair;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.TryGetComponent(out ItemBehaviour itemBehaviour))
        {
            if (_itemShield == itemBehaviour.ItemData)
            {
                ShieldBehavior shield = Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
                shield.PlayerTransform = transform;
            }

            if (_itemRepair == itemBehaviour.ItemData)
            {
                _playerHealth.CurrentHealth += 10;
            }
        }

        if (other.TryGetComponent(out Bullet _))
        {
            _playerHealth.CurrentHealth -= 1;
            if (_playerHealth.CurrentHealth == 0)
            {
                Destroy(gameObject);
            }
            Debug.Log(_playerHealth.CurrentHealth);
        }
    } 
}