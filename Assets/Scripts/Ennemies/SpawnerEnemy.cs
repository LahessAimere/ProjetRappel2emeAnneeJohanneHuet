using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;

    private BoxCollider2D _spawnArea;
    private bool _isActive;

    private void Start()
    {
        _isActive = true;
        _spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnEnemies());
    }

    private void OnDestroy()
    {
        _isActive = false;
    }

    private IEnumerator SpawnEnemies()
    {
        while (_isActive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        float spawnX = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
        float spawnY = transform.position.y;
        Instantiate(_enemyPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
    }
}