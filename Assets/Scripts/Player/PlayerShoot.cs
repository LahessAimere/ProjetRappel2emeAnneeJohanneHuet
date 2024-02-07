using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private Transform _firePoint;
    
    private void Awake()
    {
        _firePoint = transform;
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        }
    }
}
