using System.Collections;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject ennemyPrefab;
    public float spawnInterval = 2f;

    private BoxCollider2D spawnArea;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnEnnemies());
    }

    IEnumerator SpawnEnnemies()
    {
        while (true)
        {
            float spawnX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float spawnY = transform.position.y;

            Instantiate(ennemyPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}