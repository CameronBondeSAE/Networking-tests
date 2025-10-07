using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
	public TextMeshProUGUI messageText;
		
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
}
