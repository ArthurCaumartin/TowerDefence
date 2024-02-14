using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootPerSecond;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [Space]
    [SerializeField] private EnemyLife _target;
    private EnemyLife _lastFrameTarget;
    public EnemyLife Target { set => _target = value; }
    private float _shootTimer;

    void Update()
    {
        if(!_target) //TODO faire un check de la distance pour clear la target
            return;

        if(_target != _lastFrameTarget)
            _shootTimer = 0;

        _shootTimer += Time.deltaTime * _shootPerSecond;
        if (_shootTimer >= 1)
        {
            _shootTimer = 0;
            Bullet newbullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity)
                               .GetComponent<Bullet>();
            newbullet.Initialize(_target, _bulletDamage, _bulletSpeed);
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
