using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeNodeButton : MonoBehaviour, IPointerDownHandler , IPointerEnterHandler , IPointerMoveHandler , IPointerExitHandler
{
    [SerializeField] private bool _isFirstNode = false;
    [Space]
    [SerializeField] private Color _selectColor = Color.yellow;
    [SerializeField] private Color _unSelectColor = Color.gray;
    [SerializeField] private Image _images;
    [SerializeField] private List<TreeNodeButton> _connectedNodesList = new List<TreeNodeButton>();
    [SerializeField] private List<Image> _linkImagesList;
    public bool _isSelected = false;

    public bool IsOn { get => _isSelected; }
    public TreeNodeButton AddNode { set => _connectedNodesList.Add(value); }
    private TreeNodeModifier _treeNodeModifier;
    private TextMeshProUGUI _hoverText;

    void Start()
    {
        _treeNodeModifier = GetComponent<TreeNodeModifier>();
        _hoverText = GetComponentInChildren<TextMeshProUGUI>();
        SetColor();
    }

    void OnValidate()
    {
        SetColor();
    }

    public void OnClic()
    {
        print("Clic on node");
        if(CanBeClic() ==  false)
            return;

        _isSelected = !_isSelected;
        SetColor();
    }

    private bool CanBeClic()
    {
        // print("Call CanBeClic() on " + name);
        if(_connectedNodesList.Count == 0)
            return false;

        foreach (var item in _connectedNodesList)
        {
            if(item.IsOn)
            {
                if(_isFirstNode)
                    return false;
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

    public void SetHoverText(string text, bool activeValue)
    {
        _hoverText.text = text;
        _hoverText.enabled = activeValue;
    }

    public void MoveHoverText(Vector2 position)
    {
        if(!_hoverText.gameObject.activeSelf)
            return;
        RectTransform rect = (RectTransform)_hoverText.transform;
        rect.rotation = Quaternion.identity;
        rect.position = position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClic();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter ! " + name);
        SetHoverText(_treeNodeModifier.GetDescription(), true);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        // print("Move ! " + name);
        MoveHoverText(eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetHoverText("", false);
    }
}
