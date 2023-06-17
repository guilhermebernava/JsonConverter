using JsonConverter.Services;

namespace JsonConverters.Services
{
    public class ExtractServicesJsonConverter
    {
        [Fact]
        public void ShouldExtractName()
        {
            var name = ExtractServices.ExtractName("_*#Viviane Barros:*_\nIniciando sem mensagem");
            Assert.Equal("Viviane Barros", name);
        }

        [Fact]
        public void ShouldExtractText()
        {
            var text = ExtractServices.ExtractText("_*#Viviane Barros:*_\nIniciando sem mensagem");
            Assert.Equal("Iniciando sem mensagem", text);
        }

        [Fact]
        public void ShouldReturnEmptyText()
        {
            var text = ExtractServices.ExtractText("");
            Assert.Equal("", text);
        }

        [Fact]
        public void ShouldReturnEmptyName()
        {
            var name = ExtractServices.ExtractName("");
            Assert.Equal("", name);
        }
    }
}
