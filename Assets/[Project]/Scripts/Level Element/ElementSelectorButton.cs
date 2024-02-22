using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementSelectorSlot : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField] private GameObject _elementInSlot;
    [SerializeField] private Color _overColor = Color.white;
    [SerializeField] private Color _unOverColor = Color.black;
    private ElementSelector _elementSelector;
    private Image _image;
    private void Start()
    {
        _elementSelector = GetComponentInParent<ElementSelector>();
        _image = GetComponent<Image>();
        OnPointerExit(null);
    }

    public void OnClic()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _overColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        _image.color = _unOverColor;
    }
}
