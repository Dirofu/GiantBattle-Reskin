using UnityEngine;

public class EnemyFollowPlayer : Movement
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private EnemyAnimation _animation;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        _animation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        Direction = new Vector3(_player.position.x + _offset.x, transform.position.y + _offset.y, _player.position.z + _offset.z);

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Direction, Speed * Time.deltaTime);

        transform.LookAt(new Vector3(_player.position.x, transform.position.y, _player.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            Direction = new Vector3(0, transform.position.y, 0);
            _animation.ActiveAnimation = false;
        }      
    }

    public override void StopMove() { }

    public override void StartMove() { }
}
