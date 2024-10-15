using ByteBridge.Managers;
using ByteBridge.Models;


// DataModel Example
var dataModel = new DataModel
{
	Data = new byte[] { 0x01, 0x02, 0x03, 0x04 },
	Status = 0x05
};

byte[] serializedDataModel = SerializerManager.Serialize(dataModel);
Console.WriteLine("Serialized DataModel: " + BitConverter.ToString(serializedDataModel));

var deserializedDataModel = SerializerManager.Deserialize<DataModel>(serializedDataModel);
Console.WriteLine($"Deserialized DataModel - Data: {BitConverter.ToString(deserializedDataModel.Data)}, Status: {deserializedDataModel.Status}");

// UserModel Example
var userModel = new UserModel
{
	UserId = 12345,
	Username = "JohnDoe",
	IsActive = true
};

byte[] serializedUserModel = SerializerManager.Serialize(userModel);
Console.WriteLine("Serialized UserModel: " + BitConverter.ToString(serializedUserModel));

var deserializedUserModel = SerializerManager.Deserialize<UserModel>(serializedUserModel);
Console.WriteLine($"Deserialized UserModel - UserId: {deserializedUserModel.UserId}, Username: {deserializedUserModel.Username}, IsActive: {deserializedUserModel.IsActive}");

// ProductModel Example
var productModel = new ProductModel
{
	ProductId = Guid.NewGuid(),
	Name = "Laptop",
	Price = 999.99m
};

byte[] serializedProductModel = SerializerManager.Serialize(productModel);
Console.WriteLine("Serialized ProductModel: " + BitConverter.ToString(serializedProductModel));

var deserializedProductModel = SerializerManager.Deserialize<ProductModel>(serializedProductModel);
Console.WriteLine($"Deserialized ProductModel - ProductId: {deserializedProductModel.ProductId}, Name: {deserializedProductModel.Name}, Price: {deserializedProductModel.Price}");



