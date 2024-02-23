using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TreeNodeModifier : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private bool _overrideDescription = false;
    [SerializeField, TextArea] private string _description;
    public List<StatModifier> statModifierList;

    void OnValidate()
    {
        RefreshDescription();
    }

    private void RefreshDescription()
    {
        if (_overrideDescription)
            return;

        if (statModifierList.Count == 0)
        {
            _description = "";
            return;
        }

        _description = "";

        foreach (StatModifier item in statModifierList)
        {
            if (item.multiplier == Multiplier.Increased)
            {
                if (item.value < 0)
                    _description += "Decreased";
                else
                    _description += item.multiplier.ToString();
                
                _description += " " + item.statType.ToString()
                + " by " + item.value.ToString() + "%";
            }

            if (item.multiplier == Multiplier.More)
            {
                _description += item.value.ToString() + "%" + " ";
                if(item.value < 0)
                    _description += "Less";
                else
                    _description += item.multiplier.ToString();

                _description += " " + item.statType.ToString();
            }

            _description += "\r\n";
        }
    }

    public string GetDescription()
    {
        return _description;
    }
}
