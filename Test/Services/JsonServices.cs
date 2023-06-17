using System.Text.Json;
using JsonConverter.Entiteis;

namespace JsonConverter.Services
{
    public static class JsonServices
    {
        public static FileEntity ConvertJsonToFileEntity(string json)
        {
            try
            {
                var fileEntity = JsonSerializer.Deserialize<FileEntity>(json);

                if (fileEntity == null)
                {
                    throw new Exception($"ERROR IN DESERIALIZE THIS JSON \n {json}");
                }

                return fileEntity;
            }
            catch (Exception e)
            {
                throw new JsonException(e.ToString());
            }

        }
    }
}
