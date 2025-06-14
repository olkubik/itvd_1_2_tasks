using System;

public abstract class Character
{
    private string name;
    private int health;
    private int maxHealth;
    private Inventory inventory;
    protected Random random;
    public Character(string name, int maxHealth)
    {
        this.name = name;
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.inventory = new Inventory();
        random = new Random();
    }
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    public int Health
    {
        get => health;
        set => health = Clamp(value, 0, maxHealth);
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value > 0 ? value : throw new ArgumentException("MaxHealth must be positive.");
    }

    public bool IsAlive => Health > 0;

    public Inventory Inventory => inventory;

    public abstract (int damage, string message) Attack();
    public abstract bool CanAttack();
    public abstract void RestoreResource();

    // Custom Clamp method to replace Math.Clamp
    private static int Clamp(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
}
