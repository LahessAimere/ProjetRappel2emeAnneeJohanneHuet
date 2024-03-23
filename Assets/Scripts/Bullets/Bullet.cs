using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _moveSpeed = 5f;

    public float MoveSpeed => _moveSpeed;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}
