using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private List<EnnemyBehavior> _enemyInRange;


    void Update()
    {
        if(_enemyInRange.Count == 0)
            return;
        
        Vector3 ennemyDirection = _enemyInRange[0].transform.position - transform.position;
        _spriteTransform.eulerAngles = new Vector3(0, 0, Vector2.Angle(Vector2.down, ennemyDirection));
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        EnnemyBehavior ennemyBehavior = other.GetComponent<EnnemyBehavior>();
        if(ennemyBehavior && !_enemyInRange.Contains(ennemyBehavior))
            _enemyInRange.Add(ennemyBehavior);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        EnnemyBehavior ennemyBehavior = other.GetComponent<EnnemyBehavior>();
        if(ennemyBehavior && _enemyInRange.Contains(ennemyBehavior))
            _enemyInRange.Remove(ennemyBehavior);
    }
}
