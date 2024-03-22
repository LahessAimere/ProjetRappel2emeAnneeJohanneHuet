using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _playerTransform;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Transform playerTransform = playerObject.transform;
        _playerTransform = playerTransform;
    }

    public void ChasePlayer()
    {
        if (_playerTransform != null)
        {
            Vector2 directionToPlayer = (_playerTransform.position - transform.position).normalized;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0 , angle - 270f);
            transform.Translate(directionToPlayer * _moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
