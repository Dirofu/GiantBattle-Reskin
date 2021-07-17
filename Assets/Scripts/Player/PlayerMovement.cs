using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerCamera _camera;

    public Joystick Joystick => _joystick;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_joystick.Direction.x != 0 || _joystick.Direction.y != 0)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }

            Direction = new Vector3(_joystick.Horizontal * Speed, 0f, _joystick.Vertical * Speed);
            Controller.Move(Direction);

            transform.LookAt(new Vector3(Direction.x + transform.position.x, transform.position.y, Direction.z + transform.position.z));

            if (Direction != null)
            {
                _camera.SetPosition();

            }
        }
    }

    public override void StopMove() { }

    public override void StartMove() { }
}
