using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    private List<Vector3> _pathPointList = new List<Vector3>();
    private int _movementIndex;
    private float time;
    private Vector3 _offSet;

    void Start()
    {
        _offSet = Random.insideUnitCircle * .2f;
        GetLevelPath();
    }

    private void GetLevelPath()
    {
        _pathPointList.Clear();
        foreach (var item in EnemyPathManager.instance.PositionList)
            _pathPointList.Add(item.position);
    }

    void Update()
    {
        MoveThroughtPathPoint();
    }

    private void MoveThroughtPathPoint()
    {
        if (_movementIndex + 1 >= _pathPointList.Count)
        {
            EnemyManager.instance.RemoveEnnemy(gameObject);
            return;
        }

        Vector3 start = _pathPointList[_movementIndex];
        Vector3 end = _pathPointList[_movementIndex + 1];
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
