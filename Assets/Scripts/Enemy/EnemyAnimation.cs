using UnityEngine;

public class EnemyAnimation : AbstractAnimation
{
    [SerializeField] private Movement _enemy;

    public bool ActiveAnimation = true; 

    private void Start() 
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemy.Direction == new Vector3(0, transform.position.y, 0) || ActiveAnimation == false)
        {
            Animator.SetBool("isRunning", false);
        }
        else
        {
            Animator.SetBool("isRunning", true);
        }
    }

    public void ActivateRunAnimation() => Animator.SetBool("isRunning", true);
    public void DeactivateRunAnimation() => Animator.SetBool("isRunning", false);
}
