using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}