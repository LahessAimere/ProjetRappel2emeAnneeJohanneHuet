using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "ScriptableObjects/new ItemData")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("nameOfItem")] [SerializeField] private string _nameOfItem;
    [FormerlySerializedAs("backgroundColorItemItem")]
    [FormerlySerializedAs("_backgroundColorItem")] [FormerlySerializedAs("_backgroundColor")] 
    [SerializeField] private Color _backgroundColorItemItem;
    [FormerlySerializedAs("iconItemItem")]
    [FormerlySerializedAs("_iconItem")]
    [FormerlySerializedAs("_icon")]
    [ShowAssetPreview]
    [SerializeField] private Sprite _iconItemItem;

    [SerializeField] private Vector3 _iconScale;
    
    public string NameOfItem
    {
        get => _nameOfItem;
        set => _nameOfItem = value;
    }

    public Color BackgroundColorItem 
    {
        get => _backgroundColorItemItem;
        set => _backgroundColorItemItem = value;
    }

    public Sprite IconItem
    {
        get => _iconItemItem;
        set => _iconItemItem = value;
    }
    
    public Vector3 IconScale
    {
        get => _iconScale;
        set => _iconScale = value;
    }
}