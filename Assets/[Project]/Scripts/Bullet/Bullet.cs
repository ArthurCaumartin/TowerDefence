using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private EnemyLife _target;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;
    private float _targetDistance;

    public void Initialize(EnemyLife target, float damage, float speed)
    {
        _target = target;
        _bulletSpeed = speed;
        _bulletDamage = damage;
    }

    void Update()
    {
        if(!_target)
        {
            Destroy(gameObject);
            return;
        }

        _targetDistance = Vector2.Distance(transform.position,_target.transform.position);
        if(_targetDistance < .05)
        {
            _target.Life -= _bulletDamage;
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _bulletSpeed * .01f);
    }
}
