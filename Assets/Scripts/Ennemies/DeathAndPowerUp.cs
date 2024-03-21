using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class DeathAndPowerUp : MonoBehaviour
{    
    [SerializeField] private GameObject[] _powerUpPrefabs;
    [SerializeField] private float _spawnProbability = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.value < _spawnProbability && _powerUpPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, _powerUpPrefabs.Length);
            Instantiate(_powerUpPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
            
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy destroy");
    }
}