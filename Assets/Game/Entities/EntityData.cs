using System;

[Serializable]
public class EntityData
{
    public int MaxHealth;
    public float MoveSpeed;
    public float BaseDamage;

    private int currentHealth;
    public int Health { get => currentHealth; set => currentHealth = value; }
}
