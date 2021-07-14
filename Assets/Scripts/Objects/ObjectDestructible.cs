using RayFire;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class ObjectDestructible : Destructible
{
    //[SerializeField] private AudioSource _explosionSound;

    private RayfireRigid _rayFire;

    private void Start()
    {
        _rayFire = GetComponent<RayfireRigid>();
        Explosion = GetComponentInChildren<ParticleSystem>();
    }

    public override int TakeDamage(int damage)
    {
        if (damage > 0)
        {
            HealthPoint -= damage;
            Explosion.Play();
            //_explosionSound.Play();
        }

        if (HealthPoint <= 0)
        {
            DestroyObject();
        }

        return HealthPoint;
    }

    private void DestroyObject() => _rayFire.Demolish();
}
