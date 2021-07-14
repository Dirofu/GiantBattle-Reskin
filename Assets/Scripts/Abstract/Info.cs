using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Info : MonoBehaviour
{
    [SerializeField] protected Transform Target;
    [SerializeField] protected Camera Camera;

    [SerializeField] protected Image Flag;
    [SerializeField] protected TMP_Text Name;
    [SerializeField] protected TMP_Text RankDestroy;

    [SerializeField] protected Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 targetScreenPosition = Camera.WorldToScreenPoint(Target.position);
        transform.position = new Vector3(targetScreenPosition.x, targetScreenPosition.y + _offset.y);
    }

    public void ChangeRankDestroy(int rank) => RankDestroy.text = rank.ToString();
}
