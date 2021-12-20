using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _label;
    [SerializeField] private GameObject _prefab;

    public Sprite Sprite => _sprite;
    public string Label => _label;
    public GameObject Prefab => _prefab;
}
