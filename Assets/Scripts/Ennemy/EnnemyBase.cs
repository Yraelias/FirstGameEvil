using UnityEngine;

public abstract class EnemyBase
{
    public string Name { get; protected set; }
    public int MaxHP { get; protected set; }
    public int MinDamage { get; protected set; }
    public int MaxDamage { get; protected set; }

    public virtual int GetRandomDamage()
    {
        return UnityEngine.Random.Range(MinDamage, MaxDamage + 1);
    }
}