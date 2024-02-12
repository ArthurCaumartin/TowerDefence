using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    [SerializeField] private float _attackRange = 5;
    [SerializeField] private Transform _cannonTransform;
    [SerializeField] private EnemyBehavior _enemyTarget;
    public Transform a;
    private EnemyBehavior UpdateTarget()
    {
        EnemyBehavior enemyToReturn = EnemyManager.instance.GetFirstEnemyInRange(transform.position, _attackRange);
        if (enemyToReturn && Vector3.Distance(transform.position, enemyToReturn.transform.position) > _attackRange)
            return null;

        return enemyToReturn;
    }

    void Update()
    {
        _enemyTarget = UpdateTarget();
        if (!_enemyTarget)
            return;

        Vector3 ennemyDirection = (_enemyTarget.transform.position - transform.position).normalized;
        ennemyDirection.y = 0;
        _cannonTransform.right = ennemyDirection;

        // _cannonTransform.right = Vector3.Slerp(_cannonTransform.right, ennemyDirection, Time.deltaTime);
        // if(Vector3.Dot(_cannonTransform.right, ennemyDirection) > .95f)
        //     print("shoot");
    }
}
