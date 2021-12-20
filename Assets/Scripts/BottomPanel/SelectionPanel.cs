using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanel : MonoBehaviour
{
    [SerializeField] private ObjectPlacer _objectPlacer;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private ItemData[] _items;

    private void Start()
    {
        foreach(var item in _items)
        {
            AddItem(item);
        }
    }

    private void AddItem(ItemData itemData)
    {
        Instantiate(_itemPrefab, _container).TryGetComponent(out Item item);
        item.Initialize(itemData);
        item.ItemSelected += OnItemSelected;
        item.ItemDisabled += OnItemDisabled;
        
    }

    private void OnItemSelected(ItemData itemData)
    {
        _objectPlacer.SetInstalledObject(itemData);
    }
    
    private void OnItemDisabled(Item item)
    {
        item.ItemSelected -= OnItemSelected;
        item.ItemDisabled -= OnItemDisabled;
    }
}
