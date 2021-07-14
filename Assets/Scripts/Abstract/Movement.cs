using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Scale Scale;
    protected CharacterController Controller;

    public Vector3 Direction { get; protected set; }

    public void IncreaseSpeed(float speed) => Speed += speed;

    public abstract void StartMove();

    public abstract void StopMove();
}
