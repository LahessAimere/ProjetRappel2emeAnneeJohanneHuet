using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _moveSpeed;

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
            Vector2 directionToPlayer = _playerTransform.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0 , angle - 90f);
            transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime, Space.Self);
        }
    }
}
