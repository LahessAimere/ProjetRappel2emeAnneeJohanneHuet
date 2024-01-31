using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce = 10f;
    private Rigidbody2D _rigidbody2D;
    private Transform _firePoint;
    
    private void Awake()
    {
        _firePoint = transform;
        _rigidbody2D = _bulletPrefab.GetComponent<Rigidbody2D>();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        _rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }
}
