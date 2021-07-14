using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AbstractAnimation : MonoBehaviour
{
    protected Animator Animator;

    public void PlayGorillaAttack() => Animator.SetBool("GorillaAttack", true);

    public void StopGorillaAttack() => Animator.SetBool("GorillaAttack", false);

    public void PlayAttackAnimation() => Animator.SetFloat("Attack", 0.7f);

    public void StopAttackAnimation() => Animator.SetFloat("Attack", 0f);
}
