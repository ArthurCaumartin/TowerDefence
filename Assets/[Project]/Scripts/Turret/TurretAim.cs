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
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private AimMode _aimMode;

    private GameObject _enemyTarget;
    private TurretShooter _turretShooter;
    private TurretStat _stat;

    void Start()
    {
        _stat = GetComponent<TurretStat>();
        _turretShooter = GetComponent<TurretShooter>();
    }

    private GameObject UpdateTarget()
    {
        GameObject enemyToReturn = null;
        switch (_aimMode)
        {
            case AimMode.First :
                enemyToReturn = EnemyManager.instance.GetFirstEnemyInRange(transform.position, _stat.range);
            break;

            case AimMode.Random :
                enemyToReturn = EnemyManager.instance.GetRandomEnemyInRange(transform.position, _stat.range);
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

    public Vector2 GetTurretOrientation()
    {
        return _spriteTransform.up;
    }

    void OnDrawGizmos()
    {
        if(!_stat)
            _stat = GetComponent<TurretStat>();
            
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.DrawSphere(transform.position, _stat.range);
    }
}
