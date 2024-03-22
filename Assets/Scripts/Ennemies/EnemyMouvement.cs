using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void Move(float moveSpeed)
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}