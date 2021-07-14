using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Scale _scale;
    [SerializeField] private Vector3 _offsetPosition;

    private Raycast _raycast;

    private void OnEnable()
    {
        _scale.ScaleChanged += OnScaleChanged;
    }

    private void OnDisable()
    {
        _scale.ScaleChanged -= OnScaleChanged;
    }

    private void Start()
    {
        _raycast = GetComponentInChildren<Raycast>();
    }

    private void OnScaleChanged(Vector3 playerScale)
    {
        _offsetPosition.y += playerScale.y;
        _offsetPosition.z -= playerScale.y;

        _raycast.OnScaleChanged(playerScale);
    }

    public void SetPosition()
    {
        transform.position = _player.transform.position + _offsetPosition;
    }
}