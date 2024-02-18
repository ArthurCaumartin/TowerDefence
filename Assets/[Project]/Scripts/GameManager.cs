using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _timeScaleIndex = 1;

    void Awake()
    {
        instance = this;
    }

    [ContextMenu("Scale")]
    public void SwitchTimeScale()
    {
        _timeScaleIndex++;
        Time.timeScale = _timeScaleIndex % 3 == 0f ? .5f : _timeScaleIndex % 3;
        CanvasManager.instance.SetTimeScaleUI(_timeScaleIndex % 3);
    }
}
