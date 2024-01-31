using UnityEngine;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "ScriptableObjects/new ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private GameObject _item;
}
