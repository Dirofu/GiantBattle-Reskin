using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] protected int Damage;
    [SerializeField] protected int _rank = 1;
    [SerializeField] protected ParticleSystem PunchParticle;
    [SerializeField] protected Info Info;

    protected int StandartDamage;

    protected AbstractAnimation AbstractAnimation;
    protected Movement Movement;
    protected Scale Scale;

    public int RankDestroy { get; protected set; } = 1;

    public Destructible DestructibleObject { get; protected set; }
}
