using ByteBridge.Interfaces;
using ByteBridge.Models;

namespace ByteBridge.Managers
{
	public static class SerializerManager
	{
		private static readonly Dictionary<Type, Func<byte[], ICustomSerializable>> Deserializers = new();
		private static readonly Dictionary<Type, Func<ICustomSerializable, byte[]>> Serializers = new();

		// Register serializers and deserializers for each model
		static SerializerManager()
		{
			Register<DataModel>(
				(obj) => obj.Serialize(),
				(data) =>
				{
					var model = new DataModel();
					model.Deserialize(data);
					return model;
				}
			);

			Register<UserModel>(
				(obj) => obj.Serialize(),
				(data) =>
				{
					var model = new UserModel();
					model.Deserialize(data);
					return model;
				}
			);

			Register<ProductModel>(
				(obj) => obj.Serialize(),
				(data) =>
				{
					var model = new ProductModel();
					model.Deserialize(data);
					return model;
				}
			);
		}

		public static void Register<T>(Func<ICustomSerializable, byte[]> serializer, Func<byte[], ICustomSerializable> deserializer) where T : ICustomSerializable
		{
			Type type = typeof(T);
			Serializers[type] = serializer;
			Deserializers[type] = deserializer;
		}

		public static byte[] Serialize(ICustomSerializable model)
		{
			Type type = model.GetType();
			if (Serializers.TryGetValue(type, out var serializer))
			{
				return serializer(model);
			}
			throw new InvalidOperationException($"Serializer not found for type {type.FullName}");
		}

		public static T Deserialize<T>(byte[] data) where T : ICustomSerializable, new()
		{
			Type type = typeof(T);
			if (Deserializers.TryGetValue(type, out var deserializer))
			{
				return (T)deserializer(data);
			}
			throw new InvalidOperationException($"Deserializer not found for type {type.FullName}");
		}
	}
}
