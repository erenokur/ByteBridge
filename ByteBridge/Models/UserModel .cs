using ByteBridge.Interfaces;

namespace ByteBridge.Models
{
	public class UserModel : ICustomSerializable
	{
		public int UserId { get; set; }
		public string Username { get; set; } = string.Empty;
		public bool IsActive { get; set; }

		public byte[] Serialize()
		{
			using (var ms = new MemoryStream())
			using (var writer = new BinaryWriter(ms))
			{
				writer.Write(UserId);
				writer.Write(Username.Length);
				writer.Write(System.Text.Encoding.UTF8.GetBytes(Username));
				writer.Write(IsActive);
				return ms.ToArray();
			}
		}

		public void Deserialize(byte[] data)
		{
			using (var ms = new MemoryStream(data))
			using (var reader = new BinaryReader(ms))
			{
				UserId = reader.ReadInt32();
				int usernameLength = reader.ReadInt32();
				byte[] usernameBytes = reader.ReadBytes(usernameLength);
				Username = System.Text.Encoding.UTF8.GetString(usernameBytes);
				IsActive = reader.ReadBoolean();
			}
		}
	}
}
