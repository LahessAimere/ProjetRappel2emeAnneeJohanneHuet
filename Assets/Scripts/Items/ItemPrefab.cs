using UnityEngine;

public class ItemPrefab : MonoBehaviour
{
   [SerializeField] private SpriteRenderer _background;
   [SerializeField] private SpriteRenderer _icon;
   
    public void Set(ItemData itemData)
    {
        if (itemData != null)
        {
            gameObject.name = itemData.NameOfItem;
            if (itemData.IconItem != null)
            {
                _icon.sprite = itemData.IconItem;
                _icon.transform.localScale = itemData.IconScale;
            }
            _background.color = itemData.BackgroundColorItem;
        }
    }
}