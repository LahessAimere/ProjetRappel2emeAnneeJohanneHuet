using UnityEngine;
using Random = UnityEngine.Random;

public class DeathAndPowerUp : MonoBehaviour
{    
    [SerializeField] private ItemPrefab _itemPrefab;
    [SerializeField] private ItemData _itemData;
    [SerializeField] private float _spawnProbability = 0.5f;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private CountEnemyDestroy _countEnemyDestroy;

    private void Awake()
    {
        _playerScore = FindObjectOfType<PlayerScore>();
        _countEnemyDestroy = FindObjectOfType<CountEnemyDestroy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.value < _spawnProbability && _itemData)
        {
           ItemPrefab itemPrefabInstance = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
           itemPrefabInstance.Set(_itemData);
        }
        _playerScore.UpdateScore(10);
        _countEnemyDestroy.UpdateNumberOfKill(1);
            
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