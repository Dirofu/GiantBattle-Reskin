using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerAttack : Attack
{
    [SerializeField] private GameObject _destroyButton;
    [SerializeField] private CircleAttackStats _circleAttackStatus;
    [SerializeField] private float _attackRate;

    [Header("Explosion")]
    [SerializeField] private BuildingExplose _buildingExploseEffect;

    private EnemyAttack _enemy;
    private PlayerHealth _playerHealth;

    public UnityAction OnDestroyObject;

    private void Start()
    {
        AbstractAnimation = GetComponent<PlayerAnimation>();
        Scale = GetComponent<Scale>();
        _playerHealth = GetComponent<PlayerHealth>();

        StandartDamage = Damage;

        RankDestroy = _rank;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (DestructibleObject = collider.gameObject.GetComponent<Destructible>())
        {
            if (_enemy = collider.gameObject.GetComponent<EnemyAttack>())
            {   
                if (RankDestroy >= DestructibleObject.Rank && RankDestroy - _enemy.RankDestroy > 0)
                {
                    Damage = StandartDamage + (RankDestroy - _enemy.RankDestroy);
                }

                PreparingAttack(DestructibleObject.transform);
            }
            else if (RankDestroy >= DestructibleObject.Rank)
            {
                PreparingAttack(DestructibleObject.transform);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Destructible>())
        {
            DestructibleObject = null;
            StopAttack();
            Damage = StandartDamage;
        }
    }

    private void PreparingAttack(Transform target)
    {
        _circleAttackStatus.gameObject.SetActive(true);
        _circleAttackStatus.PlaceAttackCircle(target, transform);
        //AbstractAnimation.PlayAttackAnimation();
        AbstractAnimation.PlayGorillaAttack();

        StartCoroutine(AttackEnemy());
    }

    private void StopAttack()
    {
        _circleAttackStatus.gameObject.SetActive(false);

        AbstractAnimation.StopGorillaAttack();
        //AbstractAnimation.StopAttackAnimation();
    }

    public void DamageObject()
    {
        PunchParticle.Play();

        float objectHealth = DestructibleObject.TakeDamage(Damage);

        if (objectHealth <= 0)
        {
            Scale.ChangeScale();
            RankDestroy++;

            if (RankDestroy % 5 == 0)
            {
                _playerHealth.RestoreHealth();
            }

            Damage = StandartDamage;
            Info.ChangeRankDestroy(RankDestroy);

            _buildingExploseEffect.TryExplose(DestructibleObject.Rank, DestructibleObject.transform);
            OnDestroyObject?.Invoke();
            StopAttack();
        }
    }

    private IEnumerator AttackEnemy()
    {
        while(_circleAttackStatus.gameObject == true)
        {
            DamageObject();
            yield return new WaitForSeconds(_attackRate);
        }
        StopCoroutine(AttackEnemy());
    }
}