 using UnityEngine;
using UnityEngine.Serialization;

public class PowerUp : MonoBehaviour
{
    [Header("Actions Prefab")]
    [FormerlySerializedAs("_playerHealth")] [SerializeField] private PlayerHealthData playerHealthData;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ShieldBehavior _shieldPrefab;
    [SerializeField] private PauseCanva _pauseCanvas;
    
    [Header("Scriptable Objects")]
    [SerializeField] private ItemData _itemShield;
    [SerializeField] private ItemData _itemRepair;

    [SerializeField] private GameObject _itemVariantsRepair;
    [SerializeField] private GameObject _itemVariantsShield;
    
    private void Start()
    {
        _pauseCanvas = FindObjectOfType<PauseCanva>();
        if (_pauseCanvas == null)
        {
            Debug.LogError("PauseCanva reference not set in PowerUp script!");
        }
    }
    
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

    public void AddShield()
    {
        Debug.Log("AddShield");
        DestroyImmediate(gameObject, true);
        //_pauseCanvas.Resume();
        //ShieldBehavior shield = Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
        //shield.PlayerTransform = transform;
    }
    
    public void AddHealth()
    {
        Debug.Log("AddHealth");
        DestroyImmediate(gameObject, true);
        //_pauseCanvas.Resume();
        //playerHealthData.CurrentHealth += 10;
    }
}