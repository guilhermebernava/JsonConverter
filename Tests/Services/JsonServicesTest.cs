using System.Text.Json;
using JsonConverter.Entiteis;
using JsonConverter.Services;

namespace JsonConverters.Services
{
    public class JsonServicesJsonConverter
    {
        [Fact]
        public void ShouldConvertJsonToFileEntity()
        {
            var result = JsonServices.ConvertJsonToFileEntity("{\"attendanceId\":\"63efa5c7211d97aa10cb3be1\",\"protocol\":\"2023217430\",\"status\":3,\"type\":2,\"description\":\"Ricardo Vaz Psico\",\"secondaryDescription\":\"Ricardo Vaz Psico\",\"linkImage\":\"https://fileschat.sfo2.digitaloceanspaces.com/public/system/6162eeb809c4090beb437e6b/contact/5511966261140/3d20uyi.jpg\",\"countUnreadMessages\":0,\"hasTag\":false,\"lastSeen\":null,\"utcDhStartChat\":\"2023-02-17T13:05:27.278\",\"utcDhEndChat\":\"2023-02-17T14:49:01.711\",\"contact\":{\"id\":\"62c5c605e737c794261334fc\",\"name\":\"Ricardo Vaz Psico\",\"secondaryName\":\"+55 (11) 96626-1140\",\"number\":\"5511966261140\",\"linkImage\":\"https://fileschat.sfo2.digitaloceanspaces.com/public/system/6162eeb809c4090beb437e6b/contact/5511966261140/3d20uyi.jpg\",\"isMe\":false,\"tags\":[]},\"channel\":{\"id\":\"63efa4dd9b1ff8512b63ca9b\",\"type\":0,\"description\":\"Prestadores - Outros Convênios\",\"identifier\":\"+55 (11) 95891-0022\"},\"lastMessage\":{\"id\":\"63efbe0d8e39514f9b3f99dd\",\"text\":\"🔔 Chat finalizado por: Viviane Barros\",\"sender\":null,\"utcDhMessage\":\"2023-02-17T14:49:01.677\",\"utcDhMessageUnixTime\":1676656141,\"isPrivate\":false},\"currentSector\":{\"id\":\"63309698691eaee72cceadbe\",\"description\":\"Implantação outros convênios \"},\"currentOrganization\":{\"id\":\"6162eeb809c4090beb437e6c\",\"description\":\"Clinica de Especialidades Salz\"},\"currentUser\":{\"id\":\"61a75e9c3ec41a557187084c\",\"name\":\"Viviane Barros\"},\"finalizadoPor\":{\"id\":\"61a75e9c3ec41a557187084c\",\"name\":\"Viviane Barros\"},\"messages\":[{\"IdMessage\":\"63efa5c7211d97aa10cb3bef\",\"senderName\":\"Você\",\"dhMessage\":\"2023-02-17T13:05:27.33\",\"unixTimeMessage\":1676639127,\"text\":\"Chat iniciado por: Viviane Barros\",\"isSentByMe\":true,\"isDeleted\":false,\"isForwarded\":false,\"isReply\":false,\"isMMS\":false,\"isPrivate\":false,\"origen\":0,\"typeMessage\":0,\"statusMessage\":1,\"dataMedia\":null,\"dataLocation\":null,\"dataVcard\":[]},{\"IdMessage\":\"63efa5c7211d97aa10cb3c02\",\"senderName\":\"Você\",\"dhMessage\":\"2023-02-17T13:05:27.496\",\"unixTimeMessage\":1676639127,\"text\":\"_*#Viviane Barros:*_\\nIniciando sem mensagem\",\"isSentByMe\":true,\"isDeleted\":false,\"isForwarded\":false,\"isReply\":false,\"isMMS\":false,\"isPrivate\":true,\"origen\":1,\"typeMessage\":0,\"statusMessage\":1,\"dataMedia\":null,\"dataLocation\":null,\"dataVcard\":[]},{\"IdMessage\":\"63efbe0d8e39514f9b3f99dd\",\"senderName\":\"Você\",\"dhMessage\":\"2023-02-17T14:49:01.677\",\"unixTimeMessage\":1676645341,\"text\":\"Chat finalizado por: Viviane Barros\",\"isSentByMe\":true,\"isDeleted\":false,\"isForwarded\":false,\"isReply\":false,\"isMMS\":false,\"isPrivate\":false,\"origen\":0,\"typeMessage\":0,\"statusMessage\":1,\"dataMedia\":null,\"dataLocation\":null,\"dataVcard\":[]}]}");
            Assert.IsType<FileEntity>(result);
        }

        [Fact]
        public void ShouldThrowErrorWhenNotConvert()
        {
            Assert.Throws<JsonException>(() => JsonServices.ConvertJsonToFileEntity(""));
        }
    }
}
