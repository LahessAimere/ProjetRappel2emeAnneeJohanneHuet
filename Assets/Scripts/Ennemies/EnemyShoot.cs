using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootInterval = 2f;
    private bool _isActive;

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
            yield return new WaitForSeconds(_shootInterval);
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}