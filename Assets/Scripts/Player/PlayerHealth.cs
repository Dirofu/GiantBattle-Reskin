using UnityEngine.Events;

public class PlayerHealth : Destructible
{
    public UnityAction PlayerDead;

    public override int TakeDamage(int damage)
    {
        if (damage > 0)
        {
            HealthPoint -= damage;
        }

        if (HealthPoint <= 0)
        {
            PlayerDead?.Invoke();
        }

        return HealthPoint;
    }
}
