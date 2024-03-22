using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerShoot : MonoBehaviour
{
    [FormerlySerializedAs("_bulletPrefab")] [SerializeField] private GameObject _bulletPlayerPrefab;
    private Transform _firePoint;
    
    private void Awake()
    {
        _firePoint = transform;
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           Instantiate(_bulletPlayerPrefab, _firePoint.position, _firePoint.rotation);
        }
    }
}
