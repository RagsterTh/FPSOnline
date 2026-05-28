using Fusion;
using System;
using UnityEngine;

public class Bomb : NetworkBehaviour, IExplodable
{
    [SerializeField]private float bombLoadTime = 3f;//Tempo limite
    [SerializeField] private NetworkObject explosion;
    [Networked] 
    private float timer { get; set; }//Tempo que carrega

    public void ExplodeRPC(int damage)
    {
        Explode();
    }

    public override void FixedUpdateNetwork()
    {
        timer += Time.deltaTime;
        if (timer < bombLoadTime)
            return;
        Explode();
    }

    private void Explode()
    {
        Runner.Spawn(explosion, transform.position, Quaternion.identity);
        Runner.Despawn(Object);
    }
}
