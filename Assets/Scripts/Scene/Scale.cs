using UnityEngine;
using UnityEngine.Events;

public class Scale : MonoBehaviour
{
    [SerializeField] private Vector3 _growthScale;
    [SerializeField] private float _maxGrowth;

    private Movement _movement;

    private Vector3 _growthAfterDestroy;
    private float _growthRate = 2f;

    public UnityAction<Vector3> ScaleChanged;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _growthAfterDestroy = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale.x < _growthAfterDestroy.x)
        {
            transform.localScale += _growthAfterDestroy * _growthRate * Time.deltaTime;
        }
    }

    public void ChangeScale()
    {
        if (transform.localScale.x < _maxGrowth)
        {
            _growthAfterDestroy += _growthScale;
            _movement.IncreaseSpeed(_movement.StepSpeed);
            ScaleChanged?.Invoke(_growthAfterDestroy);
        }
        else
        {
            _growthAfterDestroy += _growthScale / 10;
            _movement.IncreaseSpeed(_movement.StepSpeed / 10);
            ScaleChanged?.Invoke(_growthAfterDestroy / 10);
        }
    }
}
