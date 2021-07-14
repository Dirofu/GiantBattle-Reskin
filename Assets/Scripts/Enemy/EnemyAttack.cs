using System.Collections;
using UnityEngine;

public class EnemyAttack : Attack
{
    [SerializeField] private float _timeWaitForAttack;

    private PlayerAttack _player;

    private void Start()
    {
        Movement = GetComponent<EnemyMovement>();
        AbstractAnimation = GetComponent<EnemyAnimation>();
        Scale = GetComponent<Scale>();

        StandartDamage = Damage;

        RankDestroy = _rank;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (DestructibleObject = collider.gameObject.GetComponent<Destructible>())
        {
            if (RankDestroy >= DestructibleObject.Rank && collider.gameObject.GetComponent<EnemyAttack>() == false)
            {
                if (_player = DestructibleObject.gameObject.GetComponent<PlayerAttack>())
                {
                    Damage = StandartDamage + (RankDestroy - _player.RankDestroy);

                    if (Damage < StandartDamage)
                    {
                        Damage = StandartDamage;
                    }
                }
                StartCoroutine(DamageObject());
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Destructible>())
        {
            DeleteFocusOnDestructibleObject();
            Damage = StandartDamage;
            Movement.StartMove();
        }
    }

    private void DeleteFocusOnDestructibleObject() => DestructibleObject = null;

    private IEnumerator DamageObject()
    {
        float objectHealth = DestructibleObject.Health;

        while (objectHealth > 0)
        {
            AbstractAnimation.PlayGorillaAttack();
            /*  AbstractAnimation.PlayAttackAnimation();*/
            PunchParticle.Play();
            /*  transform.LookAt(DestructibleObject.transform);*/
            Movement.StopMove();

            objectHealth = DestructibleObject.TakeDamage(Damage);

            yield return new WaitForSecondsRealtime(_timeWaitForAttack);
        }

        RankDestroy++;
        Info.ChangeRankDestroy(RankDestroy);
        AbstractAnimation.StopGorillaAttack();
        Movement.StartMove();
        Damage = StandartDamage;
        Scale.ChangeScale();
        StopCoroutine(DamageObject());
    }
}
