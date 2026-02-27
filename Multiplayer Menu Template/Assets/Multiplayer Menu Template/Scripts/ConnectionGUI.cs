using Unity.Netcode;
using UnityEngine;

public class ConnectionGUI : MonoBehaviour
{
    private void OnGUI()
    {
        if(NetworkManager.Singleton == null) return;

        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        string mode = NetworkManager.Singleton.IsHost ? "Host"
                    : NetworkManager.Singleton.IsServer ? "Server"
                    : NetworkManager.Singleton.IsClient ? "Client"
                    : "";

        GUILayout.Label("Mode: " + mode);

        GUILayout.EndArea();
    }
}
