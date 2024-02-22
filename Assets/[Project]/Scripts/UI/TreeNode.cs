using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeNode : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool _isFirstNode = false;
    [SerializeField] private List<TreeNode> _connectedNodesList;
    [Space]
    [SerializeField] private Color _selectColor = Color.yellow;
    [SerializeField] private Color _unSelectColor = Color.gray;
    [SerializeField] private Image _images;
    [SerializeField] private List<Image> _linkImagesList;
    public bool _isSelected = false;

    public bool IsOn { get => _isSelected; }
    public TreeNode AddNode { set => _connectedNodesList.Add(value); }

    void Start()
    {
        SetColor();
    }

    void OnValidate()
    {
        SetColor();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(CanBeClic() ==  false)
            return;

        // if (_upTreeNode.Count != 0 && CheckUp() == false)
        //     return;

        // if (_underTreeNode.Count != 0 && CheckUnder() == false)
        //     return;

        _isSelected = !_isSelected;
        SetColor();
    }

    private bool CanBeClic()
    {
        print("Call CanBeClic() on " + name);
        if(_connectedNodesList.Count == 0)
            return false;
        

        foreach (var item in _connectedNodesList)
        {
            if(item.IsOn)
            {
                if(_isFirstNode)
                {
                    print("Im first node");
                    return false;
                }

                return true;
            }
        }
        return false;
    }

    private void SetColor()
    {
        if (_isSelected)
        {
            _images.color = _selectColor;
            foreach (var item in _linkImagesList)
                item.color = _selectColor;
        }

        if (!_isSelected)
        {
            _images.color = _unSelectColor;
            foreach (var item in _linkImagesList)
                item.color = _unSelectColor;
        }
    }
}
