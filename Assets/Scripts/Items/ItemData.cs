using UnityEngine;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "ScriptableObjects/new ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
}
