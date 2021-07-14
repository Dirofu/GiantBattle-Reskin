using UnityEngine;
using System.Collections;

public class PlayerAbsorption : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            StartCoroutine(MovingToPlayer(other.gameObject));
        }
    }

    private IEnumerator MovingToPlayer(GameObject fragment)
    {
        if (fragment.transform.position != transform.position)
        {
            Vector3 player = new Vector3(_player.position.x, transform.position.y, _player.position.z);

            fragment.transform.position = Vector3.Lerp(fragment.transform.position, player, _speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
        else
        {
            StopCoroutine(MovingToPlayer(fragment));
        }
    }
}
