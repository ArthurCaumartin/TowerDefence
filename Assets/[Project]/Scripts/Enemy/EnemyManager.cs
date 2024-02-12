using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField] private GameObject _ennemyPrefab;
    [SerializeField] private float _spawnPerSecond;
    [SerializeField] private List<EnemyBehavior> _ennemyList;
    private float _timer;

    void Awake()
    {
        instance = this;
    }

    [ContextMenu("Spawn Ennemy")]
    public void SpawnEnnemy()
    {
        GameObject newEnnemy = Instantiate(_ennemyPrefab, LevelManager.instance.PositionList[0].position, Quaternion.identity);
        EnemyBehavior newBehavior = newEnnemy.GetComponent<EnemyBehavior>();
        _ennemyList.Add(newBehavior);
    }

    void Update()
    {
        _timer += Time.deltaTime * _spawnPerSecond;
        if(_timer > 1)
        {
            _timer = 0;
            SpawnEnnemy();
        }
    }

    public EnemyBehavior GetFirstEnemyInRange(Vector3 turretPosition, float turretRange)
    {
        for (int i = 0; i < _ennemyList.Count; i++)
        {
            float currentDistance = Vector3.Distance(turretPosition, _ennemyList[i].transform.position);
            if(currentDistance < turretRange)
            {
                return _ennemyList[i];
            }
        }
        return null;
    }

    public void RemoveEnnemy(EnemyBehavior toRemove)
    {
        if(_ennemyList.Contains(toRemove))
            _ennemyList.Remove(toRemove);
    }
}
