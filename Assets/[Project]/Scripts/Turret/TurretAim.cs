using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
enum AimMode
{
    First,
    Random,
}

public class TurretAim : MonoBehaviour
{
    [Header("Reference :")]
    [SerializeField] private TurretShooter _turretShooter;
    [SerializeField] private Transform _spriteTransform;
    [Header("Parametre :")]
    [SerializeField] private AimMode _aimMode;
    [SerializeField] private float _range = 5;
    [SerializeField] private GameObject _enemyTarget;

    private GameObject UpdateTarget()
    {
        GameObject enemyToReturn = null;
        switch (_aimMode)
        {
            case AimMode.First :
                enemyToReturn = EnemyManager.instance.GetFirstEnemyInRange(transform.position, _range);
            break;

            case AimMode.Random :
                enemyToReturn = EnemyManager.instance.GetRandomEnemyInRange(transform.position, _range);
            break;
        }

        return enemyToReturn;
    }

    void Update()
    {
        if(!_enemyTarget)
            _enemyTarget = UpdateTarget();


        if (!_enemyTarget)
        {
            _turretShooter.Target = null;
            return;
        }

        Vector3 ennemyDirection = (_enemyTarget.transform.position - transform.position).normalized;

        _spriteTransform.up = ennemyDirection;
        _turretShooter.Target = _enemyTarget.GetComponent<EnemyLife>();

        // if (Vector2.Dot(_spriteUp, ennemyDirection) > .95f)
        // else
        //     _turretShooter.Target = null;

        // _cannonTransform.right = Vector3.Slerp(_cannonTransform.right, ennemyDirection, Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.DrawSphere(transform.position, _range);
    }
}
