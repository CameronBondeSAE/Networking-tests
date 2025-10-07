using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
	public TextMeshProUGUI messageText;
		
	// Server to Clients
	[Rpc(SendTo.ClientsAndHost, RequireOwnership = true, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToClients_Rpc(string message)
	{
		Debug.Log("Server: " + message);
		messageText.text += "Server: "+message + "\n";
	}

	[Rpc(SendTo.Server, RequireOwnership = true, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToServerFromClient_Rpc(string message)
	{
		Debug.Log("Client: "+message);
		messageText.text += "Client: "+message + "\n";
	}
	
	// Client to Server
	[Rpc(SendTo.Server, RequireOwnership = false, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToServerFromClient(string message)
	{
		Debug.Log("*** Message from client: "+message);
	}
}
