using Fusion;
using UnityEngine;

public class PlayerInteractions : NetworkBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] private NetworkObject _minion;
    [Networked, OnChangedRender(nameof(ColorChanged))]
    public Color NetworkedColor { get; set; }

    private void Start()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void Update()
    {
        if (HasStateAuthority == false)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            NetworkedColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
        if(Input.GetButtonDown("Fire2"))
        {
            Runner.Spawn(_minion, transform.position + new Vector3(0, 0.5f, 0) + (transform.forward * 2), Quaternion.identity, Runner.LocalPlayer);
            //Runner.Despawn(Object);
        }
    }
    private void ColorChanged()
    {
        _meshRenderer.material.color = NetworkedColor;
    }
}
