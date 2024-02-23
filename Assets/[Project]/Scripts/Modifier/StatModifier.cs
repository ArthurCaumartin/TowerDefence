using System;

public enum Multiplier
{
    Increased,
    More,
}

[Serializable]
public enum StatType
{
    Damage,
    AttackSpeed,
    Range,
}

[Serializable]
public class StatModifier
{
    public StatType statType;
    public Multiplier multiplier;
    public float value;
}
