using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float _maxLife;
    [SerializeField] private float _currentLife;

    [Header("UI Elements :")]
    [SerializeField] private Image _lifeBarImage;
    public float Life
    {
        get => _currentLife;
        set 
        {
            _currentLife = value;
            SetLifeBarFill();
            if(_currentLife <= 0)
                EnemyManager.instance.RemoveEnnemy(gameObject);
        }
    }

    void Start()
    {
        _currentLife = _maxLife;
    }

    private void SetLifeBarFill()
    {
        _lifeBarImage.fillAmount = Mathf.InverseLerp(0, _maxLife, _currentLife);
    }
}
