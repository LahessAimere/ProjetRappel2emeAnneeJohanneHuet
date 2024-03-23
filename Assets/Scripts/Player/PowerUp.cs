using UnityEngine;
using UnityEngine.Serialization;

public class PowerUp : MonoBehaviour
{

    [FormerlySerializedAs("_playerHealth")] [SerializeField] private PlayerHealthData playerHealthData;
    [SerializeField] private Inventory _inventory;
    
    [Header("Scriptable Objects")]
    [SerializeField] private ItemData _itemShield;
    [SerializeField] private ItemData _itemRepair;

    [SerializeField] private GameObject _itemVariantsRepair;
    [SerializeField] private GameObject _itemVariantsShield;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ItemBehaviour itemBehaviour))
        {
            if (_itemShield == itemBehaviour.ItemData)
            {
                _inventory.AddItem(_itemVariantsShield);
                _inventory.UpdateInventorySlots();
            }

            if (_itemRepair == itemBehaviour.ItemData)
            {
                _inventory.AddItem(_itemVariantsRepair);
                _inventory.UpdateInventorySlots();
            }
        }

        if (other.TryGetComponent(out Bullet _))
        {
            playerHealthData.CurrentHealth -= 1;
            if (playerHealthData.CurrentHealth == 0)
            {
                Destroy(gameObject);
            }
            Debug.Log(playerHealthData.CurrentHealth);
        }
    } 
}