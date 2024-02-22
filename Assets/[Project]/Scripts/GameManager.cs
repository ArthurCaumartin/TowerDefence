using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _timeScaleIndex = 1;
    private Dictionary<Vector3Int, GameObject> _levelElements = new Dictionary<Vector3Int, GameObject>();

    void Awake()
    {
        instance = this;
    }

    public void SwitchTimeScale()
    {
        _timeScaleIndex++;
        Time.timeScale = _timeScaleIndex % 3 == 0f ? .5f : _timeScaleIndex % 3;
        CanvasManager.instance.SetTimeScaleUI(_timeScaleIndex % 3);
    }

    public void PlaceElement(GameObject element, Vector3Int spawnPos)
    {
        if (_levelElements.ContainsKey(spawnPos))
        {
            Destroy(_levelElements[spawnPos]);
            _levelElements.Remove(spawnPos);
            return;
        }
        
        GameObject newElement = Instantiate(element, spawnPos + (Vector3.one * .5f), Quaternion.identity);
        _levelElements.Add(spawnPos, newElement);
    }

    public void RemoveElement(Vector3Int elementPosition)
    {
        if(_levelElements.ContainsKey(elementPosition))
        {
            Destroy(_levelElements[elementPosition]);
            _levelElements.Remove(elementPosition);
        }
    }
}
