using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField]private int damage = 5;
    private void OnTriggerEnter(Collider collision)
    {
        IExplodable target = collision.GetComponentInParent<IExplodable>();
        if (target == null)
            return;
        target.ExplodeRPC(damage);
    }
}
