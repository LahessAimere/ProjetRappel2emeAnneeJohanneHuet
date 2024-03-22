using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float _size = 400f;
    [SerializeField] private GameObject[] _inventorySlots;

    private int _numPoint;
    private ListItemDatasInventory _listItemDatas;

    private InputAction _navigationAction;
    private Vector2 _navigationInput;
    private int _selectedButtonIndex;
    private const float _tau = 2 * Mathf.PI;
    

    // private void OnEnable()
    // {
    //     _navigationAction.performed += OnNavigation;
    //     _navigationAction.Enable();
    // }
    //
    // private void OnDisable()
    // {
    //     _navigationAction.canceled -= OnNavigation;
    //     _navigationAction.Disable();
    // }

    public void OnNavigation(InputAction.CallbackContext context)
    {
        _navigationInput = context.ReadValue<Vector2>();

        if (_navigationInput.x > 0)
        {
            _selectedButtonIndex = (_selectedButtonIndex + 1) % _numPoint;
        }
        else if (_navigationInput.x < 0)
        {
            _selectedButtonIndex = (_selectedButtonIndex - 1 + _numPoint) % _numPoint;
        }
    }
    
    private void Start()
    {
        _inventorySlots = new GameObject[_numPoint];
    }

    public void AddItem(GameObject itemPrefab)
    {
        _numPoint++;
        ResizeInventorySlots(_numPoint);

        float tauMultiplier = _tau / _numPoint;
        for (int i = 0; i < _numPoint; i++)
        {                               
            float x = Mathf.Cos(tauMultiplier * i) * _size;
            float y = Mathf.Sin(tauMultiplier * i) * _size;

            Vector3 itemPosition = transform.position + new Vector3(x, y, 0);

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
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }

        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (_inventorySlots[i] == null)
            {
                if (i < children.Count)
                {
                    _inventorySlots[i] = children[i];
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        float tauMultiplier = _tau / _numPoint;
    
        for (int i = 0; i < _numPoint; i++)
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
    
            float nextX = Mathf.Cos(_tau * (i + 1) / _numPoint) * _size;
            float nextY = Mathf.Sin(_tau * (i + 1) / _numPoint) * _size;
    
            Vector3 nextPoint = transform.position + new Vector3(nextX, nextY, 0);
    
            Handles.color = Color.magenta;
            Handles.DrawLine(currentPoint, nextPoint);
        }
    
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, _size);
    }
}
