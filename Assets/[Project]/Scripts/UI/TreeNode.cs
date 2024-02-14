using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeNode : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TreeNode _UpTreeNode;
    [SerializeField] private TreeNode _underTreeNode;
    [Space]
    [SerializeField] private Color _selectColor = Color.yellow;
    [SerializeField] private Color _unSelectColor = Color.gray;
    [SerializeField] private List<Image> _images;
    private bool _isSelected = false;
    public bool IsOn { get => _isSelected; }

    void Start()
    {
        foreach (var item in _images)
            item.color = _isSelected ? _selectColor : _unSelectColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_UpTreeNode && _UpTreeNode.IsOn)
            return;

        if (_underTreeNode && !_underTreeNode.IsOn)
            return;

        _isSelected = !_isSelected;
        print("Clic on node : " + name);
        if (_isSelected)
        {
            foreach (var item in _images)
                item.color = _selectColor;
        }

        if (!_isSelected)
        {
            foreach (var item in _images)
                item.color = _unSelectColor;
        }
    }
}
