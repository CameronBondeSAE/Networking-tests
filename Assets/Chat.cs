using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
		
	[Rpc(SendTo.ClientsAndHost, RequireOwnership = true, Delivery = RpcDelivery.Reliable)]
	public void SendMessageToClients_Rpc(string message)
	{
		Debug.Log("Sending message: " + message);
	}
	//
	// public void ReceiveMessage(string message)
	// {
	// 	Debug.Log("Received message: " + message);
	// }
}
