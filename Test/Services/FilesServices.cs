using Test.Entiteis;

namespace Test.Services
{
    public static class FilesServices
    {
        public static async Task ReadDirectoriesAndSaveConvertedFiles(string folderPath, string folderToSavePath)
        {
            await Task.Run(() =>
            {
                foreach (string file in Directory.EnumerateFiles(folderPath, "*.json"))
                {
                    string json = File.ReadAllText(file);
                    var fileEntity = JsonServices.ConvertJsonToFileEntity(json);
                    SaveFile(folderToSavePath, fileEntity);
                }
            });

            Console.WriteLine("Finished All Files");
            Console.ReadLine();
        }

        private static void SaveFile(string filePath, FileEntity entity)
        {
            var path = filePath + entity.attendanceId + ".txt";
            if (File.Exists(path))
            {
                Console.WriteLine($"Pulei Arquivo - {entity.attendanceId}");
                return;
            }

            using (StreamWriter writer = File.CreateText(path))
            {
                FormatFileEntity(writer, entity);
            }
            Console.WriteLine($"FILE SAVED - {entity.attendanceId}");

        }

        private static void FormatFileEntity(StreamWriter writer, FileEntity entity)
        {
            writer.WriteLine("---------------------------------------------------------------------");
            writer.WriteLine($"ATTENDANCE ID: {entity.attendanceId}");
            writer.WriteLine($"PROTOCOL: {entity.protocol}");
            writer.WriteLine($"STATUS: {entity.status}");
            writer.WriteLine($"TYPE: {entity.type}");
            writer.WriteLine($"DESCRIPTION: {entity.description}");
            writer.WriteLine($"SECUNDARY DESCRIPTION: {entity.secondaryDescription}");
            writer.WriteLine($"LINK IMAGE: {entity.linkImage}");
            writer.WriteLine($"COUNT UNREAD MESSAGES: {entity.countUnreadMessages}");
            writer.WriteLine($"HAS TAG: {entity.hasTag}");
            writer.WriteLine($"LAST SEEN: {entity.lastSeen}");
            writer.WriteLine($"UTC DH START CHAT: {entity.utcDhStartChat?.ToString("dd/MM/yyyy")}");
            writer.WriteLine($"UTC DH END CHAT: {entity.utcDhEndChat?.ToString("dd/MM/yyyy")}");
            writer.WriteLine($"UTC DH END CHAT: {entity.utcDhEndChat?.ToString("dd/MM/yyyy")}");
            writer.WriteLine("---------------------------------------------------------------------");

            if (entity.contact != null)
            {
                writer.WriteLine();
                writer.WriteLine("---------------------------------------------------------------------");
                writer.WriteLine($"CONTACT");
                writer.WriteLine($"ID: {entity.contact.id}");
                writer.WriteLine($"NAME: {entity.contact.name}");
                writer.WriteLine($"SECUNDARY NAME: {entity.contact.secondaryName}");
                writer.WriteLine($"NUMBER: {entity.contact.number}");
                writer.WriteLine($"IS ME: {entity.contact.isMe}");
                writer.WriteLine($"LINK IMAGE: {entity.contact.linkImage}");
                writer.WriteLine($"TAGS: ");
                foreach (var tag in entity.contact.tags)
                {
                    writer.WriteLine($" -> {tag}");
                }
                writer.WriteLine("---------------------------------------------------------------------");
            }

            writer.WriteLine();
            writer.WriteLine("---------------------------------------------------------------------");
            writer.WriteLine($"MESSAGES");
            foreach (var message in entity.messages)
            {
                writer.WriteLine();
                if (message.text.Contains("_*#"))
                {
                    writer.WriteLine($" {ExtractServices.ExtractName(message.text)}({message.dhMessage?.ToString("dd/MM/yyyy HH:mm:ss")}): {ExtractServices.ExtractText(message.text)}");
                    continue;
                }
                writer.WriteLine($" {message.senderName}({message.dhMessage?.ToString("dd/MM/yyyy HH:mm:ss")}): {message.text}");

            }
            writer.WriteLine("---------------------------------------------------------------------");

            writer.WriteLine();
            if (entity.finalizadoPor != null)
            {
                writer.WriteLine("---------------------------------------------------------------------");
                writer.WriteLine($"FINALIZADO POR");
                writer.WriteLine($"ID: {entity.finalizadoPor.id ?? ""}");
                writer.WriteLine($"NAME: {entity.finalizadoPor.name ?? ""}");
                writer.WriteLine("---------------------------------------------------------------------");
            }
        }
    }


}
