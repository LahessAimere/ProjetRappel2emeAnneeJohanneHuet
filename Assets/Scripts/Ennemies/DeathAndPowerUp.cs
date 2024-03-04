using UnityEngine;

public class DeathAndPowerUp : MonoBehaviour
{    
    [SerializeField] private ItemPrefab _itemPrefab;
    [SerializeField] private ItemData _itemData;
    [SerializeField] private float _spawnProbability = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.value < _spawnProbability && _itemData)
        {
           ItemPrefab itemPrefabInstance = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
           itemPrefabInstance.Set(_itemData);
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