using UnityEngine;

public class PlayerAnimation : AbstractAnimation
{
    private PlayerMovement _player;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_player.Joystick.Horizontal != 0 || _player.Joystick.Vertical != 0)
        {
            Animator.SetBool("isRunning", true);
        }
        else
        {
            Animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAttackAnimation();
    }

    public void Die() => Animator.SetTrigger("Die");
}
