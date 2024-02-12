using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootInterval = 2f;
    [SerializeField] private LayerMask _playerLayer;
    
    private bool _isActive;
    private float _detectionDistance = 10f;

    private void Start()
    {
        _isActive = true;
        StartCoroutine(ShootRoutine());
    }

    private void OnDestroy()
    {
        _isActive = false;
    }

    private IEnumerator ShootRoutine()
    {
        while (_isActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _detectionDistance, _playerLayer);
            
            if (hit.collider != null)
            {
                Shoot();
            }
            yield return new WaitForSeconds(_shootInterval);
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _detectionDistance);
    }
}