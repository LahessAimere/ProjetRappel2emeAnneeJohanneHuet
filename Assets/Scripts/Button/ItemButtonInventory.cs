using UnityEngine;
using UnityEngine.InputSystem;

public class ItemButtonInventory : MonoBehaviour
{
    [SerializeField] private PlayerHealthData _playerHealthData;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PauseCanva _pauseCanvas;
    private PlayerInput _playerInput;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private ShieldBehavior _shieldPrefab;


    private void Start()
    {
        if (_inventory == null)
        {
            _inventory = FindObjectOfType<Inventory>();
        }

        if (_pauseCanvas == null)
        {
            _pauseCanvas = FindObjectOfType<PauseCanva>();
        }

        if (_playerInput == null)
        {
            _playerInput = FindObjectOfType<PlayerInput>();
        }

        if (_player == null)
        {
            _player = FindObjectOfType<PlayerMovement>();
        }
    }

    public void AddShield()
    {
        Debug.Log("AddShield");
        _pauseCanvas.Resume();
        _playerInput.SwitchCurrentActionMap("Game");
        ShieldBehavior shield = Instantiate(_shieldPrefab, _player.transform.position, Quaternion.identity, _player.transform).GetComponent<ShieldBehavior>();
        shield.PlayerTransform = transform;
        Destroy(gameObject);
    }
    
    public void AddHealth()
    {
        Debug.Log("AddHealth");
        _pauseCanvas.Resume();
        _playerInput.SwitchCurrentActionMap("Game");
        
        if (_playerHealthData.CurrentHealth < 100)
        {
            _playerHealthData.CurrentHealth += 10;
        }
        
        if (_playerHealthData.CurrentHealth > 100)
        {
            _playerHealthData.CurrentHealth = 100;
        }

        Destroy(gameObject);
    }
}
