namespace ByteBridge.Interfaces
{
	public interface ICustomSerializable
	{
		byte[] Serialize();
		void Deserialize(byte[] data);
	}
}
