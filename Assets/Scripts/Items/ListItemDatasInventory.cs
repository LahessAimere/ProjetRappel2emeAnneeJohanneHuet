using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_ListItemDatas", menuName = "ScriptableObjects/new ListItemDatasInventory")]
public class ListItemDatasInventory : ScriptableObject
{
    [SerializeField] private List<ItemData> _listItemDatas;
    public List<ItemData> ListItemDatas
    {
        get => _listItemDatas;
        set => _listItemDatas = value;
    }
}