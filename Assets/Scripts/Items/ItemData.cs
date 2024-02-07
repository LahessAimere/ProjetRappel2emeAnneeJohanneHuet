using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "ScriptableObjects/new ItemData")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("_name")] [SerializeField] private string nameOfItem;

    public string NameOfItem
    {
        get => nameOfItem;
        set => nameOfItem = value;
    }
}