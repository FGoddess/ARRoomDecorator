using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image _imgae;
    [SerializeField] private Text _text;
    [SerializeField] private Button _selectionButton;

    private ItemData _itemData;

    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<Item> ItemDisabled;

    private void OnEnable()
    {
        _selectionButton.onClick.AddListener(() => ItemSelected?.Invoke(_itemData));
    }

    private void OnDisable()
    {
        ItemDisabled?.Invoke(this);
        _selectionButton.onClick.RemoveListener(() => ItemSelected?.Invoke(_itemData));
    }

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
        _imgae.sprite = _itemData.Sprite;
        _text.text = _itemData.Label;
    }
}
