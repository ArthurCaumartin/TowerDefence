using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private EnemyLife _target;
    private EnemyLife _lastFrameTarget;
    public EnemyLife Target { set => _target = value; }
    private float _shootTimer;
    private TurretStat _stat;
    private TurretAim _turretAim;

    void Start()
    {
        _stat = GetComponent<TurretStat>();
        _turretAim = GetComponent<TurretAim>();
    }

    void Update()
    {
        if(!_target) //TODO faire un check de la distance pour clear la target
            return;

        if(_target != _lastFrameTarget)
            _shootTimer = 0;

        _shootTimer += Time.deltaTime * _stat.attackPerSecond;
        if (_shootTimer >= 1)
        {
            _shootTimer = 0;
            Vector2 bulletSpawn = _turretAim.GetTurretOrientation();
            bulletSpawn = transform.TransformPoint(bulletSpawn * .5f);

            Bullet newbullet = Instantiate(_bulletPrefab, bulletSpawn, Quaternion.identity)
                               .GetComponent<Bullet>();
            newbullet.Initialize(_target, _stat.damage, _stat.bulletSpeed);
        }

        _lastFrameTarget = _target;
    }

    void OnDrawGizmos()
    {
        if (!_target)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _target.transform.position);
    }
}
