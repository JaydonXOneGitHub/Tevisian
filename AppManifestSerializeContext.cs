using System.Text.Json.Serialization;

[JsonSerializable(typeof(Tev.Core.AppManifest))]
[JsonSerializable(typeof(string))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public partial class AppManifestSerializeContext : JsonSerializerContext
{
}