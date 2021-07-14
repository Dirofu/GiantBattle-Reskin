using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private int _countShakes;
    [SerializeField] private float _frequency;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, 0);

    public void Shaking() => StartCoroutine(ShakeCamera());

    private IEnumerator ShakeCamera()
    {
        for (int i = 0; i < _countShakes; i++)
        {
            transform.position += _offset;
            yield return new WaitForSeconds(_frequency);
            transform.position -= _offset;
            yield return new WaitForSeconds(_frequency);
        }
        StopCoroutine(ShakeCamera());
    }
}
