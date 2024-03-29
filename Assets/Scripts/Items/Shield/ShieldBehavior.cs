using System.Collections;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
   [SerializeField] private float _shieldCountdown = 5f;
   private Transform _playerTransform;

   public Transform PlayerTransform
   {
      set => _playerTransform = value;
   }
   
   private void Start()
   {
      StartCoroutine(StartShieldCountdown());
   }

   private void Update()
   {
      transform.position = _playerTransform.position;
      if (_playerTransform == null)
      {
         Destroy(gameObject);
      }
   }

   private void OnDestroy()
   {
      StopCoroutine(StartShieldCountdown());
   }

   private IEnumerator StartShieldCountdown()
   {
      yield return new WaitForSeconds(_shieldCountdown);

      Destroy(gameObject);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log(other.name);
   }
}