using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
	public TextMeshProUGUI messageText;

	private void OnEnable()
	{
		// Subscribe (react to) clients joining and leaving
		NetworkManager.Singleton.OnClientConnectedCallback += SingletonOnOnClientConnectedCallback;
		NetworkManager.Singleton.OnClientDisconnectCallback += SingletonOnOnClientDisconnectCallback;
	}

	private void OnDisable()
	{
		NetworkManager.Singleton.OnClientConnectedCallback -= SingletonOnOnClientConnectedCallback;
		NetworkManager.Singleton.OnClientDisconnectCallback -= SingletonOnOnClientDisconnectCallback;
	}

	private void SingletonOnOnClientConnectedCallback(ulong clientID)
	{
		messageText.text += "Client connected: " + clientID + "\n";
	}

	private void SingletonOnOnClientDisconnectCallback(ulong clientID)
	{
		messageText.text += "Client disconnected: " + clientID + "\n";
	}

	
	

	// Server to Clients
	[Rpc(SendTo.ClientsAndHost, RequireOwnership = true, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToClientsFromServer_Rpc(string message)
	{
		Debug.Log("Server: " + message);
		messageText.text += "Server: " + message + "\n";
	}

	// Client to Server
	[Rpc(SendTo.Server, RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToServerFromClient_Rpc(string message)
	{
		Debug.Log("*** Message from client: " + message);
		SendMessageToClientsFromServer_Rpc(message);
	}
}