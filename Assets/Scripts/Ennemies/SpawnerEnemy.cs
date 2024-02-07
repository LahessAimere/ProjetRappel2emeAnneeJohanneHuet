using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ennemyPrefab;
    
    private BoxCollider2D _spawnArea;
    private float _spawnInterval = 2f;
    private bool _isActive;


    void Start()
    {
        _isActive = true;
        _spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnEnnemies());
    }

    private void OnDestroy()
    {
        _isActive = false;
    }

    IEnumerator SpawnEnnemies()
    {
        while (_isActive)
        {
            float spawnX = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
            float spawnY = transform.position.y;

            Instantiate(_ennemyPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}