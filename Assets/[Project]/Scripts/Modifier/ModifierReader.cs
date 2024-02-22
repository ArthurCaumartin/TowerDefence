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
        int lessOrMore = 0;

        for (int i = 0; i < _modifierList.Count; i++)
        {
            //! Get the "value%" part of the string
            string stringMult = _modifierList[i].Split("%")[0];
            stringMult = stringMult.Split(" ")[stringMult.Split(" ").Length - 1];
            

            //! Determine increased / decreased
            lessOrMore = _modifierList[i].Contains(Tag_Incearsed) ? 1 : -1;

            //! Target the stat
            if (_modifierList[i].Contains(Tag_Damage))
                _totalDamage += Convert.ToInt32(stringMult) * lessOrMore;

            if (_modifierList[i].Contains(Tag_AttackSpeed))
                _totalAttackSpeed += Convert.ToInt32(stringMult) * lessOrMore;

            if (_modifierList[i].Contains(Tag_Range))
                _totalRange += Convert.ToInt32(stringMult) * lessOrMore;
        }

        DamageMultiplier = 1 + (_totalDamage / 100);
        AttackSpeedMultiplier = 1 + (_totalAttackSpeed / 100);
        RangeMultiplier = 1 + (_totalRange / 100);
    }

    private bool IsNumerical(char value)
    {
        if(value == '0')
            return true;
        if(value == '1')
            return true;
        if(value == '2')
            return true;
        if(value == '3')
            return true;
        if(value == '4')
            return true;
        if(value == '5')
            return true;
        if(value == '6')
            return true;
        if(value == '7')
            return true;
        if(value == '8')
            return true;
        if(value == '9')
            return true;
        
        return false;
    }
}
