using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    private List<Vector3> _positionList = new List<Vector3>();
    private int _movementIndex;
    private float time;
    private Vector3 _offSet;

    void Start()
    {
        _offSet = Random.insideUnitCircle * .2f;

        _positionList.Clear();
        foreach (var item in LevelManager.instance.PositionList)
            _positionList.Add(item.position);
    }

    void Update()
    {
        if (_movementIndex + 1 >= _positionList.Count)
        {
            EnemyManager.instance.RemoveEnnemy(gameObject);
            return;
        }

        Vector3 start = _positionList[_movementIndex];
        Vector3 end = _positionList[_movementIndex + 1];
        float distance = Vector3.Distance(start, end);

        time += Time.deltaTime * _speed / distance;
        transform.position = Vector3.Lerp(start, end, time) + _offSet;

        if (time >= 1)
        {
            time = 0;
            _movementIndex++;
        }
    }
}
