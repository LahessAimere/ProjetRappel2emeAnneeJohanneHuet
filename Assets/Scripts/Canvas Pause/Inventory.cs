using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float _size = 400f;
    [SerializeField] private GameObject[] _inventorySlots;

    private int _selectedButtonIndex;
    private const float _tau = 2 * Mathf.PI;

    private void Start()
    {
        int numChildren = transform.childCount;
        _inventorySlots = new GameObject[numChildren];
    }

    public void AddItem(GameObject itemPrefab)
    {
        int numChildren = transform.childCount;
        ResizeInventorySlots(numChildren);

        float tauMultiplier = _tau / numChildren;
        for (int i = 0; i < numChildren; i++)
        {                               
            float x = Mathf.Cos(tauMultiplier * i) * _size;
            float y = Mathf.Sin(tauMultiplier * i) * _size;

            Vector3 itemPosition = transform.position + new Vector3(x, y, 0);
            Debug.Log(itemPosition);

            if (_inventorySlots[i] == null)
            {
                GameObject newItem = Instantiate(itemPrefab, itemPosition, Quaternion.identity, transform);
                Debug.Log(newItem.transform.position);
                newItem.transform.localScale = new Vector3(140f, 140f, 140f);
                _inventorySlots[i] = newItem;
            }
            else
            {
                _inventorySlots[i].transform.position = itemPosition;
            }
        }
    }
    
    private void ResizeInventorySlots(int newSize)
    {
        GameObject[] newInventorySlots = new GameObject[newSize];
        for (int i = 0; i < Mathf.Min(newSize, _inventorySlots.Length); i++)
        {
            newInventorySlots[i] = _inventorySlots[i];
        }
        _inventorySlots = newInventorySlots;
    }

    private void Update()
    {
        UpdateInventorySlots();
    }

    public void UpdateInventorySlots()
    {
        int numChildren = transform.childCount;

        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (_inventorySlots[i] == null)
            {
                if (i < numChildren)
                {
                    _inventorySlots[i] = transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        int numChildren = transform.childCount;
        float tauMultiplier = _tau / numChildren;
    
        for (int i = 0; i < numChildren; i++)
        {
            float x = Mathf.Cos(tauMultiplier * i) * _size;
            float y = Mathf.Sin(tauMultiplier * i) * _size;
    
            Vector3 currentPoint = transform.position + new Vector3(x, y, 0);
    
            float buttonSize = 0.1f;
            float buttonRadius = buttonSize * HandleUtility.GetHandleSize(currentPoint);
    
            if (i == _selectedButtonIndex)
            {
                Handles.color = Color.green;
            }
            else
            {
                Handles.color = Color.white;
            }
    
            Handles.DrawSolidDisc(currentPoint, Vector3.forward, buttonRadius);
    
            float nextX = Mathf.Cos(_tau * (i + 1) / numChildren) * _size;
            float nextY = Mathf.Sin(_tau * (i + 1) / numChildren) * _size;
    
            Vector3 nextPoint = transform.position + new Vector3(nextX, nextY, 0);
    
            Handles.color = Color.magenta;
            Handles.DrawLine(currentPoint, nextPoint);
        }
    
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, _size);
    }
}