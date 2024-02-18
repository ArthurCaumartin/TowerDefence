using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : MonoBehaviour
{
    [SerializeField] private GameObject _turretOnSlot;
    private TurretSelector _selector;
    private LineRenderer _lineRenderer;

    void Start()
    {
        _selector = GetComponentInParent<TurretSelector>();
        if (_selector)
            _selector.NodeList.Add(this);
        else
            print("SELECTOR NOT FOND !");

        _lineRenderer = GetComponent<LineRenderer>();


        SetTurretDysplay();
    }

    public void SetTurretDysplay()
    {
        if (!_turretOnSlot)
            return;

        GameObject newDisplay = Instantiate(_turretOnSlot, transform);
        newDisplay.transform.localPosition = Vector3.zero;
        newDisplay.transform.localScale *= .5f;
        foreach (var item in newDisplay.GetComponentsInChildren<SpriteRenderer>())
            item.sortingOrder += 50;
    }

    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _selector.transform.position);
    }
}
