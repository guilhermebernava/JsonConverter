using JsonConverter.Entiteis;

namespace JsonConverter.Services
{
    public static class FilesServices
    {
        public static async Task ReadDirectoriesAndSaveConvertedFiles(string folderPath, string folderToSavePath)
        {

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.json"))
            {
                string json = File.ReadAllText(file);
                var fileEntity = JsonServices.ConvertJsonToFileEntity(json);
                await SaveFile(folderToSavePath, fileEntity);
            }

            Console.WriteLine("Finished All Files");
            Console.ReadLine();
        }

        private static async Task SaveFile(string filePath, FileEntity entity)
        {
            try
            {
                var userFolder = "";
                if (entity.currentUser == null)
                {
                    userFolder = entity.protocol + " " + entity.utcDhStartChat?.ToString("dd-MM-yyyy");

                }
                else
                {
                    userFolder = entity.currentUser.name + " " + entity.utcDhStartChat?.ToString("dd-MM-yyyy");

                }
                var dirPath = filePath + userFolder + "\\";
                Directory.CreateDirectory(dirPath);
                var path = dirPath + entity.protocol + ".txt";


                if (File.Exists(path))
                {
                    Console.WriteLine($"Pulei Arquivo - {entity.attendanceId}");
                    return;
                }

                using (StreamWriter writer = File.CreateText(path))
                {
                    await FormatFileEntity(writer, entity, dirPath);
                }
                Console.WriteLine($"FILE SAVED - {entity.attendanceId}");
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private static async Task DownloadFile(Message message, string path)
        {
            if (File.Exists(path + message.dataMedia.filename) || message.dataMedia.urlFile == "")
            {
                return;
            }
                using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(message.dataMedia.urlFile);
                    if(!response.IsSuccessStatusCode)
                    {
                        return;
                    }

                    using (var fileStream = new FileStream(path + message.dataMedia.filename, FileMode.Create))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }

                    Console.WriteLine("Download concluído com sucesso!");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private static async Task FormatFileEntity(StreamWriter writer, FileEntity entity, string path)
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
            writer.WriteLine($"UTC DH START CHAT: {entity.utcDhStartChat?.ToString("dd/MM/yyyy HH:mm:ss")}");
            writer.WriteLine($"UTC DH END CHAT: {entity.utcDhEndChat?.ToString("dd/MM/yyyy HH:mm:ss")}");
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
                }
                else
                {
                    writer.WriteLine($" {message.senderName}({message.dhMessage?.ToString("dd/MM/yyyy HH:mm:ss")}): {message.text}");

                }

                if (message.dataMedia != null)
                {
                    await DownloadFile(message, path);
                    writer.WriteLine();
                    writer.WriteLine($"     * TIPO DO ARQUIVO: {message.dataMedia.type}");
                    writer.WriteLine($"     * NOME DO ARQUIVO: {message.dataMedia.filename}");
                    writer.WriteLine($"     * URL ARQUIVO: {message.dataMedia.urlFile}");
                    writer.WriteLine();
                }

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
