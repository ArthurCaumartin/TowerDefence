using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField] private GameObject _ennemyPrefab;
    [SerializeField] private float _spawnPerSecond;
    [SerializeField] private List<GameObject> _ennemyList;
    private float _timer;

    void Awake()
    {
        instance = this;
    }

    [ContextMenu("Spawn Ennemy")]
    public void SpawnEnnemy()
    {
        GameObject newEnnemy = Instantiate(_ennemyPrefab, LevelManager.instance.PositionList[0].position, Quaternion.identity);
        _ennemyList.Add(newEnnemy);
    }

    void Update()
    {
        _timer += Time.deltaTime * _spawnPerSecond;
        if (_timer > 1)
        {
            _timer = 0;
            SpawnEnnemy();
        }
    }

    public GameObject GetFirstEnemyInRange(Vector3 turretPosition, float turretRange)
    {
        for (int i = 0; i < _ennemyList.Count; i++)
        {
            float currentDistance = Vector3.Distance(turretPosition, _ennemyList[i].transform.position);
            if (currentDistance < turretRange)
                return _ennemyList[i];
        }
        return null;
    }

    public GameObject GetRandomEnemyInRange(Vector3 turretPosition, float turretRange)
    {
        if(_ennemyList.Count == 0)
            return null;
        //! Get all enemy in range of the tower
        List<GameObject> enemyInRange = new List<GameObject>();
        foreach (GameObject item in _ennemyList)
        {
            if (Vector2.Distance(turretPosition, item.transform.position) < turretRange)
                enemyInRange.Add(item);
        }

        if (enemyInRange.Count == 0)
            return null;
        
        return enemyInRange[Random.Range(0, enemyInRange.Count)];
    }

    public void RemoveEnnemy(GameObject toRemove)
    {
        if (_ennemyList.Contains(toRemove))
            _ennemyList.Remove(toRemove);
        Destroy(toRemove);
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        GUILayout.Label("Current enemy number : " + _ennemyList.Count);
    }
}
