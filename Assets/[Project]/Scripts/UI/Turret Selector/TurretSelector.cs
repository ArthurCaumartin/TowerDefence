using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretSelector : MonoBehaviour
{
    [SerializeField] private float _animationDuration = .5f;
    [SerializeField] private List<SelectorNode> _nodeList;
    public List<SelectorNode> NodeList { get => _nodeList; }

    public void DisplaySelector(Vector3 displayPos)
    {
        //! z pos edit to rendre above tilemap
        displayPos.z = -5f;
        gameObject.SetActive(true);
        transform.position = displayPos;
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, _animationDuration)
        .SetUpdate(true);
    }

    public void HideSelector()
    {
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, _animationDuration)
        .SetUpdate(true)
        .OnComplete(() => gameObject.SetActive(false));
    }
}
