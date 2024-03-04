using UnityEngine;

public class ItemPrefab : MonoBehaviour
{
   [SerializeField] private SpriteRenderer _icon;
   [SerializeField] private Color _backgroundColor;
   
    private ItemData _itemData;

    public void Set(ItemData itemData)
    {
        if (itemData != null)
        {
            _itemData = itemData;
            gameObject.name = itemData.NameOfItem;
            _backgroundColor = itemData.SpriteColor;
            
            if (itemData.Icon != null)
            {
                _icon.sprite = itemData.Icon;
            }
        }
    }
}