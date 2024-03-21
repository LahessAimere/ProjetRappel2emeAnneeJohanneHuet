using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootInterval = 2f;
    
    private bool _isActive;
    private float _detectionDistance = 10f;

    private void Start()
    {
        _isActive = true;
        StartCoroutine(ShootRoutine(_shootInterval));
    }

    private void OnDestroy()
    {
        _isActive = false;
    }

    public IEnumerator ShootRoutine(float _shootInterval)
    {
        while (_isActive)
        { 
            Shoot();
            yield return new WaitForSeconds(_shootInterval);
        }
    }

    public void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _detectionDistance);
    }
}