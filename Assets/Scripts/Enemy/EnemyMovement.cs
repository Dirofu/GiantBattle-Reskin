using UnityEngine;

public class EnemyMovement : Movement
{
    private EnemyAnimation _animation;

    private float _maxTimeSwitch = 3f;
    private float _timeBeforeSwitchDirection = 0f;
    private bool _isAttack = false;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        _animation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        TryChangeTowards();
        Move();
        _timeBeforeSwitchDirection -= Time.deltaTime;
    }

    private void TryChangeTowards()
    {
        if (_timeBeforeSwitchDirection <= 0)
        {
            Direction = new Vector3(Random.Range(-1, 2) * Speed, transform.position.y, Random.Range(-1, 2) * Speed);            

            if (Direction.x == 0 && Direction.z == 0 && _isAttack == false)
            {
                Direction = new Vector3(1 * Speed, transform.position.y, Random.Range(-1, 2) * Speed);
            }

            _timeBeforeSwitchDirection = _maxTimeSwitch;
        }
    }

    private void Move()
    {
        Controller.SimpleMove(Direction);

        transform.LookAt(new Vector3(Direction.x + transform.position.x, transform.position.y, Direction.z + transform.position.z));
    }

    public override void StartMove()
    {
        _timeBeforeSwitchDirection = 0;
        _animation.ActivateRunAnimation();
    }

    public override void StopMove()
    {
        Direction = new Vector3(0, transform.position.y, 0);
        _timeBeforeSwitchDirection = _maxTimeSwitch;
        _animation.DeactivateRunAnimation();
    }
}
