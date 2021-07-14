using UnityEngine;
using RayFire;
using System.Collections;

public class EnemyHealth : Destructible
{
    [SerializeField] private GameObject _info;

    private RayfireRigid _rigid;

    private void Start()
    {
        _rigid = GetComponentInChildren<RayfireRigid>();
    }

    private void Dead()
    {
        Destroy(_info);
        _rigid.Demolish();
        Destroy(gameObject);
    }

    public override int TakeDamage(int damage)
    {
        if (damage > 0)
        {
            HealthPoint -= damage;
        }

        if (HealthPoint <= 0)
        {
            Dead();
        }

        return HealthPoint;
    }
}
