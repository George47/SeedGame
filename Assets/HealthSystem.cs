using System;

public class HealthSystem
{
    private int Health;
    private int MaxHealth;

    // use this instead of update to save resource
    public event EventHandler OnhealthChange;

    public HealthSystem(int MaxHealth)
    {
        this.MaxHealth = MaxHealth;
        Health = MaxHealth;
    }

    public int GetHealth()
    {
        return Health;
    }

    public void Damage(int DamageAmount)
    {
        Health -= DamageAmount;
        if (Health < 0) Health = 0;
        if (OnhealthChange != null) OnhealthChange(this, EventArgs.Empty);

        // and on setup, can do healthSystem.OnhealthChange
        // to notify theres a change on health
    }
    public void Heal(int HealAmount)
    {
        Health += HealAmount;
        if (Health > MaxHealth) Health = MaxHealth;
        if (OnhealthChange != null) OnhealthChange(this, EventArgs.Empty);
    }
}
