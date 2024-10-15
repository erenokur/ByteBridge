using System.IO.Ports;

namespace ByteBridge.Managers
{
	public class SerialCommunicationManager
	{
		private SerialPort _serialPort;

		public SerialCommunicationManager(string portName, int baudRate)
		{
			_serialPort = new SerialPort(portName, baudRate);
			_serialPort.Open();
		}

		public void SendData(byte[] dataToSend)
		{
			try
			{
				_serialPort.Write(dataToSend, 0, dataToSend.Length);
				Console.WriteLine("Data sent successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error sending data: {ex.Message}");
			}
		}

		public void Close()
		{
			_serialPort.Close();
		}
	}
}
