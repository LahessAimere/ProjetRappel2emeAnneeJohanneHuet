using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "ScriptableObjects/new ItemData")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("_name")] [SerializeField] private string nameOfItem;
    [FormerlySerializedAs("_spriteColor")] [SerializeField] private Color _backgroundColor;
    [ShowAssetPreview]
    [SerializeField] private Sprite _icon;
    
    public string NameOfItem
    {
        get => nameOfItem;
        set => nameOfItem = value;
    }

    public Color SpriteColor
    {
        get => _backgroundColor;
        set => _backgroundColor = value;
    }

    public Sprite Icon
    {
        get => _icon;
        set => _icon = value;
    }
}