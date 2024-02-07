using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

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
