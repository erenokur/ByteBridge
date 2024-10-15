using ByteBridge.Interfaces;

namespace ByteBridge.Models
{
	public class DataModel : ICustomSerializable
	{
		public byte[] Data { get; set; } = new byte[4];
		public byte Status { get; set; }

		public byte[] Serialize()
		{
			if (Data.Length != 4)
				throw new ArgumentException("Data must be exactly 4 bytes.");

			byte[] result = new byte[5];
			Array.Copy(Data, 0, result, 0, 4);
			result[4] = Status;
			return result;
		}

		public void Deserialize(byte[] data)
		{
			if (data.Length != 5)
				throw new ArgumentException("Data must be exactly 5 bytes.");

			Array.Copy(data, 0, Data, 0, 4);
			Status = data[4];
		}
	}
}
