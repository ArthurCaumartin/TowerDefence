using System.Collections;
using System.Collections.Generic;
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
}
