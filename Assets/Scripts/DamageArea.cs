using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out IExplodable target))
            return;
        target.ExplodeRPC();
    }
}
