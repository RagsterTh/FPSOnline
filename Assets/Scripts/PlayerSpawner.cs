using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField]private NetworkObject PlayerPrefab;

    void IPlayerJoined.PlayerJoined(PlayerRef player)
    {
        if (player != Runner.LocalPlayer)
            return;

        //Runner.Spawn é o Instantiate do online
        //Só funciona com objetos que tem NetworkObject
        Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);

    }
}
