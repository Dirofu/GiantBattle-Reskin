using UnityEngine;

public class CircleAttackStats : MonoBehaviour
{
    private int _sizeIncrease = 2;

    private void ChangeCircleScale(Transform size)
    {
        transform.localScale = new Vector3(size.transform.localScale.x + _sizeIncrease, size.transform.localScale.y + _sizeIncrease);
    }

    public void PlaceAttackCircle(Transform target, Transform size)
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = new Vector3(target.position.x, 1, target.position.z);
        ChangeCircleScale(size);
    }
}
