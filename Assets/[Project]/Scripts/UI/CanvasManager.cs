using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("Time Scale stuff :")]
    [SerializeField] private List<Image> _scaleImageLsit;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetTimeScaleUI(1);
    }

    public void SetTimeScaleUI(int index)
    {
        if(index > 3)
        {
            Debug.LogWarning("Time Scale index to hight !!!");
            return;
        }
        foreach (var item in _scaleImageLsit)
            item.enabled = false;
        
        for (int i = 0; i < index + 1; i++)
            _scaleImageLsit[i].enabled = true;
    }
}
