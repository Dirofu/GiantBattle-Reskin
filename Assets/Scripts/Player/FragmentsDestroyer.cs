using UnityEngine;

public class FragmentsDestroyer : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<Rigidbody>())
        {
            Destroy(collider.gameObject);
        }
    }
}
