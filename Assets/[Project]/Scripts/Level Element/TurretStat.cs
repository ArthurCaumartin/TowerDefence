using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TurretStat : MonoBehaviour
{
    //TODO utiliser des delegate pour l'attaque au moment de bake les turret

    [SerializeField] private float _critChanceBase = .05f;
    [SerializeField] private float _critMultiplierBase = .05f;

    [SerializeField] private float _damageBase = 5;
    [SerializeField] private float _damageIncreased = 1;
    [SerializeField] private float _damageMore = 1;
    public float Damage { get => _damageBase * _damageIncreased * _damageMore; }
    [Space]
    [SerializeField] private float _attackSpeedBase = 5;
    [SerializeField] private float _attackIncreasedSpeed = 1;
    [SerializeField] private float _attackSpeedMore = 1;
    public float AttackSpeed { get => _attackSpeedBase * _attackIncreasedSpeed * _attackSpeedMore; }
    [Space]
    [SerializeField] private float _rangeBase = 5;
    [SerializeField] private float _rangeIncreased = 1;
    [SerializeField] private float _rangeMore = 1;
    public float Range { get => _rangeBase * _rangeIncreased * _rangeMore; }
    [Space]
    [SerializeField] private float _bulletSpeedBase = 10;
    [SerializeField] private float _bulletSpeedIncreased = 1;
    [SerializeField] private float _bulletSpeedMore = 1;
    public float BulletSpeed { get => _bulletSpeedBase * _bulletSpeedIncreased * _bulletSpeedMore; }

    public void BakeTurret(List<TreeNodeModifier> nodeList)
    {
        float damage = 1;
        float attackSpeed = 1;
        float range = 1;
        float bulletSpeed = 1;
        //TODO implement bulletSpeed stat

        foreach (TreeNodeModifier item in nodeList)
        {
            foreach (StatModifier mod in item.statModifierList)
            {
                if (mod.statType == StatType.Damage)
                    damage += mod.value;
                if (mod.statType == StatType.AttackSpeed)
                    attackSpeed += mod.value;
                if (mod.statType == StatType.Range)
                    range += mod.value;
                if(mod.statType == StatType.BulletSpeed)
                    bulletSpeed += mod.value;
            }
        }

        _damageIncreased = 1 + (damage / 100);
        _attackIncreasedSpeed = 1 + (attackSpeed / 100);
        _rangeIncreased = 1 + (range / 100);
        _bulletSpeedIncreased = 1 + (bulletSpeed / 100);
    }
}
