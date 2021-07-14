using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Vector3 _player;
    [SerializeField] private Shader _transparent;
    [SerializeField] private Shader _standard;
    [SerializeField] private Transform _rayStart;

    private MeshRenderer _currentObject;
    
    private int _layerMask = 1 << 7;

    private RaycastHit _hit;
    private Color _objectColor;

    private void Update()
    {
        if (Physics.Raycast(_rayStart.position, _player, out _hit, Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(_rayStart.position, _player * _hit.distance, Color.red);

            SetTransparentObject();
        }
        else
        {
            Debug.DrawRay(_rayStart.position, _player * 3f, Color.white);
            SetOpaqueObject();
        }
    }

    private void SetTransparentObject()
    {
        _currentObject = _hit.collider.gameObject.GetComponent<MeshRenderer>();

        _currentObject.material.shader = _transparent;

        _objectColor = _currentObject.material.color;
        _objectColor.a = .35f;
        _currentObject.material.color = _objectColor;
    }

    private void SetOpaqueObject()
    {
        _objectColor.a = 1f;
        _currentObject.material.color = _objectColor;
        _currentObject.material.shader = _standard;
    }

    public void OnScaleChanged(Vector3 playerScale)
    {
        _rayStart.transform.position = new Vector3(_rayStart.transform.position.x, _rayStart.transform.position.y, _rayStart.transform.position.z + playerScale.y);
    }
}
