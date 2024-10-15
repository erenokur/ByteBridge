using ByteBridge.Interfaces;

namespace ByteBridge.Models
{
	public class ProductModel : ICustomSerializable
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }

		public byte[] Serialize()
		{
			using (var ms = new MemoryStream())
			using (var writer = new BinaryWriter(ms))
			{
				writer.Write(ProductId.ToByteArray());

				byte[] nameBytes = System.Text.Encoding.UTF8.GetBytes(Name);
				writer.Write(nameBytes.Length);
				writer.Write(nameBytes);

				writer.Write(Price);
				return ms.ToArray();
			}
		}

		public void Deserialize(byte[] data)
		{
			using (var ms = new MemoryStream(data))
			using (var reader = new BinaryReader(ms))
			{
				byte[] guidBytes = reader.ReadBytes(16);
				ProductId = new Guid(guidBytes);

				int nameLength = reader.ReadInt32();
				byte[] nameBytes = reader.ReadBytes(nameLength);
				Name = System.Text.Encoding.UTF8.GetString(nameBytes);

				Price = reader.ReadDecimal();
			}
		}
	}
}
