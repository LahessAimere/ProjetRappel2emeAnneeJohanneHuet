using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{ 
   [SerializeField] private float _moveSpeed = 5f;
   [SerializeField] private ItemData _itemData;

   public ItemData ItemData
   {
      get => _itemData;
      set => _itemData = value;
   }
   
   void Update()
   {
      transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      Destroy(gameObject);
   }
   
   private void OnBecameInvisible()
   {
      Destroy(gameObject);
   }
}
