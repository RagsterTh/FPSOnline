using Fusion;
using UnityEngine;

public class PlayerStatus : NetworkBehaviour, IExplodable
{
    private Vector3 _origin;
    [Networked, OnChangedRender(nameof(HealthChanged))]
    private float NetworkedHealth { get; set; } = 10;


    public override void Spawned()
    {
        _origin = transform.position;
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void ExplodeRPC(int damage)
    {
        NetworkedHealth -= damage;
        if (NetworkedHealth > 0)
            return;
        print("Player morreu");
        //Aqui o player morre, pode ser uma animação de morte, ou um respawn
        transform.position = _origin;
    }

    private void HealthChanged()
    {
        //Para atualizar a hud de vida caso exista
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
