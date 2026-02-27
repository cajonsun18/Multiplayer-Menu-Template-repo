using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkModeManager : MonoBehaviour
{
    [Header("Local Game Input")]
    [SerializeField] private TMP_InputField LocalGameHostIPInput;
    [SerializeField] private TMP_InputField LocalGameHostPortInput;

    [SerializeField] private TMP_InputField LocalGameClientIPInput;
    [SerializeField] private TMP_InputField LocalGameClientPortInput;

    public static event Action OnNetworkStartedEvent;

    public void OnStartLocalHostClicked()
    {
        bool success = SetUpUnityTransport(LocalGameHostIPInput.text, LocalGameHostPortInput.text);

        if (!success) return;

        StartHost();
    }

    public void OnStartLocalClientClicked()
    {
        bool success = SetUpUnityTransport(LocalGameClientIPInput.text, LocalGameClientPortInput.text);

        if (!success) return;

        StartClient();
    }

    private bool SetUpUnityTransport(string ipAdress, string portAdress)
    {
        ushort internalPort;

        bool success = ushort.TryParse(portAdress, out internalPort);

        if (!success) return false; 

        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        transport.SetConnectionData(ipAdress, internalPort);

        return true;
    }

    private void StartHost()
    {
        bool success = NetworkManager.Singleton.StartHost();

        if (success)
        {
            OnNetworkStartedEvent?.Invoke();
        }
    }

    private void StartServer()
    {
        bool success = NetworkManager.Singleton.StartServer();

        if (success)
        {
            OnNetworkStartedEvent?.Invoke();
        }
    }

    private void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
