using UnityEngine;

public class DeathAndPowerUp : MonoBehaviour
{
    [SerializeField] private float _spawnProbability = 0.5f;
    [SerializeField] private ItemPrefab _itemPrefab;
    [SerializeField] private ItemData[] _itemDataArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.value < _spawnProbability && _itemDataArray != null && _itemDataArray.Length > 0)
        {
            ItemData chosenItemData = _itemDataArray[Random.Range(0, _itemDataArray.Length)];

            if (chosenItemData != null)
            {
                ItemPrefab itemPrefabInstance = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
                itemPrefabInstance.Set(chosenItemData);
                ItemBehaviour itemBehaviour = itemPrefabInstance.gameObject.AddComponent<ItemBehaviour>();
                itemBehaviour.ItemData = chosenItemData;
            }
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}