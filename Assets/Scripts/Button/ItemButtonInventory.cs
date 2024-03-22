using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButtonInventory : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _item;

    private void Start()
    {
        _inventory = GetComponentInParent<Inventory>();
    }

    public void SetItem(GameObject item)
    {
        _item = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item != null)
        {
            //_inventory.UseItem(_item);
        }
    }
}
