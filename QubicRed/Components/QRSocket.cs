using System;
using System.Collections.Generic;
using System.ComponentModel;
using Quobject.SocketIoClientDotNet.Client;
using QubicRed.Components.QRSocket_Extras;

namespace QubicRed.Components
{
	public partial class QRSocket : Component
	{
		public delegate void MessageReceived(SocketMessage e);
		public event MessageReceived OnMessageReceived;
		public delegate void SocketEventHadnler(SocketEvent e);
		public event SocketEventHadnler SocketEvent;

		public Socket WebSocket { get; protected set; }

		public QRSocket()
		{
			InitializeComponent();
		}

		public QRSocket(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public void Init()
		{
			// TODO: Implement a way for the server to tell the client they are ready to communicate
			WebSocket = IO.Socket("https://qubicredserver-frosenos.rhcloud.com:8443/");
			//WebSocket = IO.Socket("http://localhost:8080/");
			//WebSocket = IO.Socket("https://home-frosenos.rhcloud.com:8443/");
			WebSocket.On(Socket.EVENT_CONNECT, () =>
			{
				SocketEvent?.Invoke(new SocketEvent("Connected", true));
			});
			WebSocket.On(Socket.EVENT_DISCONNECT, () =>
			{
				SocketEvent?.Invoke(new SocketEvent("Connected", false));
			});
			WebSocket.On("message", (data) => { OnMessageReceived?.Invoke(new SocketMessage(data)); });
			WebSocket.On("login", (data) => { SocketEvent?.Invoke(new SocketEvent("login", data)); });
			WebSocket.On("friendslist", (data) => { SocketEvent?.Invoke(new SocketEvent("friendslist", data)); });
			WebSocket.On("conversations", (data) => { SocketEvent?.Invoke(new SocketEvent("conversations", data)); });
		}

		public void Send(string eventName, SocketMessage data)
		{
			WebSocket.Emit(eventName, data.ToJSON());
		}

		public void RegisterModule(string module)
		{
			WebSocket.Emit("module", module);
		}
	}

	public class SocketEvent
	{
		public string Name { get; protected set; }
		public object Data { get; protected set; }

		public SocketEvent(string _name, object _data) { Name = _name; Data = _data; }
	}
}
