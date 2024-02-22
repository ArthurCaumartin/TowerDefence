using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifierReader : MonoBehaviour
{
    //! Increased damage by 40%
    [SerializeField] private List<string> _modifierList;

    public float DamageMultiplier;
    public float AttackSpeedMultiplier;
    public float RangeMultiplier;

    float _totalDamage;
    float _totalAttackSpeed;
    float _totalRange;

    const string Tag_Incearsed = "Increased";
    const string Tag_Damage = "damage";
    const string Tag_AttackSpeed = "attack speed";
    const string Tag_Range = "range";

    private void Start()
    {
        ReadModifier();
    }

    public void AcctualiseMultiplier()
    {
        ReadModifier();
    }

    private void ReadModifier()
    {
        //TODO refaire en générique sur l'ordre de la formulation
        int multiplier = 0;

        for (int i = 0; i < _modifierList.Count; i++)
        {
            //! Get the "value%" part of the string
            string stringMult = _modifierList[i].Split("%")[0];
            stringMult = stringMult.Split(" ")[stringMult.Split(" ").Length - 1];

            //! Determine increased / decreased
            multiplier = _modifierList[i].Contains(Tag_Incearsed) ? 1 : -1;

            //! Target the stat
            if (_modifierList[i].Contains(Tag_Damage))
                _totalDamage += Convert.ToInt32(stringMult) * multiplier;

            if (_modifierList[i].Contains(Tag_AttackSpeed))
                _totalAttackSpeed += Convert.ToInt32(stringMult) * multiplier;

            if (_modifierList[i].Contains(Tag_Range))
                _totalRange += Convert.ToInt32(stringMult) * multiplier;
        }

        DamageMultiplier = 1 + (_totalDamage / 100);
        AttackSpeedMultiplier = 1 + (_totalAttackSpeed / 100);
        RangeMultiplier = 1 + (_totalRange / 100);
    }
}
