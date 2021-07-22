using UnityEngine;

public abstract class Destructible : MonoBehaviour
{
    [SerializeField] protected int RankObject;
    [SerializeField] protected int HealthPoint;
    [SerializeField] protected ParticleSystem Explosion;
    [SerializeField] protected ParticleSystem Heal;

    protected int HealthPerLevel;
    protected int MaxHealth;

    public int Health => HealthPoint;

    private void Awake()
    {
        MaxHealth = HealthPoint;
        HealthPerLevel = MaxHealth / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DeadZone>())
        {
            TakeDamage(HealthPoint);
        }
    }

    public int Rank => RankObject;

    public abstract int TakeDamage(int damage);

    public void RestoreHealth()
    {
        if (HealthPoint < MaxHealth)
        {
            HealthPoint += HealthPerLevel;
            Heal.Play();
        }
        else
        {
            HealthPoint = MaxHealth;
            Heal.Play();
        }
    }
}
