using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerCamera _camera;

    private PlayerHealth _health;
    private bool _canMove = true;

    public Joystick Joystick => _joystick;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.PlayerDead += StopMove;
    }

    private void OnDisable()
    {
        _health.PlayerDead -= StopMove;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {  
        if (_joystick.Direction.x != 0 || _joystick.Direction.y != 0 && _canMove == true)
        {
            Direction = new Vector3(_joystick.Horizontal * Speed, 0f, _joystick.Vertical * Speed);
            Controller.Move(Direction);

            transform.LookAt(new Vector3(Direction.x + transform.position.x, transform.position.y, Direction.z + transform.position.z));

            if (Direction != null)
            {
                _camera.SetPosition();
            }
        }

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    public override void StopMove() => _canMove = false;

    public override void StartMove() { }
}
