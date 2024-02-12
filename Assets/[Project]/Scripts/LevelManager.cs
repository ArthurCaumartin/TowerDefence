using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private List<Transform> _positionList;
    public List<Transform> PositionList { get => _positionList; }

    void Awake()
    {
        instance = this;
    }

    [ContextMenu("Add Level Point |(｡◕‿‿◕｡)|")]
    public void AddLevelPoint()
    {
        _positionList.Clear();

        for (int i = 0; i < transform.childCount; i++)
            _positionList.Add(transform.GetChild(i).transform);
    }

    void OnDrawGizmos()
    {
        if (_positionList.Count < 1)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < _positionList.Count; i++)
        {
            if (i + 1 < _positionList.Count)
            {
                Gizmos.DrawLine(_positionList[i].position, _positionList[i + 1].position);
                for (float y = 0; y < 1 && !Application.isPlaying; y += .01f)
                    Gizmos.DrawSphere(Vector3.Lerp(_positionList[i].position, _positionList[i + 1].position, y), .2f);
            }
        }
    }
}
