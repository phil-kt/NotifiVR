using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class communicates with the sensors and determines when there is a notification. Notification information is sent to the corresponding 
 * notifiers which handle how the the notification information is output into the environment.
 */
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;
using System;

 
[System.Serializable]
public class NotificationManager : MonoBehaviour {
	protected Dictionary<NotificationType, List<NotificationObject>> notifierObjMap;
	const int PORT = 5000;
	const string IP_ADDRESS = "143.215.89.51"; // Put Computer's IP address here (will be same one on Android phone)
	Queue<string> notificationQueue = new Queue<string>();
	Thread thread;
	IPAddress localAddress;
	TcpListener listener;
	TcpClient client;

	public void Awake() {
		localAddress = IPAddress.Parse(GetLocalIPAddress());
		listener = new TcpListener(localAddress, PORT);
	}

	public void Start() {
		notifierObjMap = new Dictionary<NotificationType, List<NotificationObject>> ();
		NotificationObject[] notifierObjects = (NotificationObject[])FindObjectsOfType (typeof(NotificationObject));
		Debug.Log ("Notifier objects found in scene: " + notifierObjects.Length);
		for (int i = 0; i < notifierObjects.Length; i++) {
			NotificationObject n = notifierObjects [i];
			List<NotificationType> types = n.getNotificationTypes ();
			for (int j = 0; j < types.Count; j++) {
				NotificationType currType = types [j];
				if (!notifierObjMap.ContainsKey (currType)) {
					notifierObjMap [currType] = new List<NotificationObject> ();
				}

				notifierObjMap [currType].Add (n);
			}
		}
			
		if (NetworkInterface.GetIsNetworkAvailable ()) {
			thread = new Thread (new ThreadStart (ConnectPhone));
			thread.Start ();
		}
		//ConnectPhone ();
	}

	public void Update (){
		// Listen for notifications
		string data = null;
		if (notificationQueue.Count > 0) {
			data = notificationQueue.Dequeue ();
		}
		if (Input.GetKeyDown ("space")) {
			if (notifierObjMap.ContainsKey (NotificationType.PHONE_INCOMING_CALL)) {
				List<NotificationObject> notifierList = notifierObjMap [NotificationType.PHONE_INCOMING_CALL];
				for (int i = 0; i < notifierList.Count; i++) {
					if (notifierList [i].CanHandle (NotificationType.PHONE_INCOMING_CALL)) {
						notifierList [i].TriggerNotification (NotificationType.PHONE_INCOMING_CALL);
					}
				}
			}
		} else if (Input.GetKeyDown ("n") || data != null) {
			if (notifierObjMap.ContainsKey (NotificationType.PHONE_TEXT_MESSAGE)) {
				List<NotificationObject> notifierList = notifierObjMap [NotificationType.PHONE_TEXT_MESSAGE];
				for (int i = 0; i < notifierList.Count; i++) {
					if (notifierList [i].CanHandle (NotificationType.PHONE_TEXT_MESSAGE)) {
						notifierList [i].TriggerNotification (NotificationType.PHONE_TEXT_MESSAGE);
					}
				}
			}
		}
	}

	public void ConnectPhone() {
		Debug.Log("Listening for phone...");
		listener.Start();

		// Creates accepted client and reads in data from network stream
		client = listener.AcceptTcpClient();

		// Sets up and starts TCP listener to listen at port 5000
		NetworkStream stream = client.GetStream();

		// Gets byte data and converts it back to a string
		byte[] streamBuffer = new byte[client.ReceiveBufferSize];
		int bytesRead = stream.Read(streamBuffer, 0, client.ReceiveBufferSize);
		string data = Encoding.ASCII.GetString(streamBuffer, 0, bytesRead);
		notificationQueue.Enqueue (data);
		Debug.Log("Notification Recieved: " + data);



	}

	public void OnApplicationQuit() {
		// Stops the listener, later on can remove this to make it always active possibly
		if (client != null) {
			client.Close ();
		}
			
		listener.Stop();
	}

	public static string GetLocalIPAddress() {
		var host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (var ip in host.AddressList)
		{
			if (ip.AddressFamily == AddressFamily.InterNetwork)
			{
				return ip.ToString();
			}
		}
		throw new Exception("Local IP Address Not Found!");
	}
}
