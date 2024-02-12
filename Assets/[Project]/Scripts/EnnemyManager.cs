using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    public static EnnemyManager instance;
    [SerializeField] private GameObject _ennemyPrefab;
    [SerializeField] private float _spawnPerSecond;
    [SerializeField] private List<EnnemyBehavior> _ennemyList;
    private float _timer;

    void Awake()
    {
        instance = this;
    }

    [ContextMenu("Spawn Ennemy")]
    public void SpawnEnnemy()
    {
        GameObject newEnnemy = Instantiate(_ennemyPrefab, LevelManager.instance.PositionList[0]);
        EnnemyBehavior newBehavior = newEnnemy.GetComponent<EnnemyBehavior>();
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

    public void RemoveEnnemy(EnnemyBehavior toRemove)
    {
        if(_ennemyList.Contains(toRemove))
            _ennemyList.Remove(toRemove);
    }
}
