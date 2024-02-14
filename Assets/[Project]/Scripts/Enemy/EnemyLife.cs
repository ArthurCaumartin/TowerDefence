using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float _maxLife;
    [SerializeField] private float _currentLife;
    public float Life
    {
        get => _currentLife;
        set 
        {
            _currentLife = value;
            if(_currentLife <= 0)
            EnemyManager.instance.RemoveEnnemy(gameObject);
        }
    }

    void Start()
    {
        _currentLife = _maxLife;
    }
}
