using JsonConverter.Exceptions;

namespace JsonConverter.Services
{
    public static class ExtractServices
    {
        public static string ExtractName(string input)
        {
            if (input.Length == 0)
            {
                return "";
            }
            try
            {
                string name = input.Split(":")[0];
                string cleanName = name.Replace("_n", " ").Replace("_", "").Replace("#", "").Replace("*", "").Replace(":", "").Replace("_n", "");
                return cleanName;
            }
            catch (Exception ex)
            {
                throw new ExtractException(ex.ToString());
            }
            
        }

        public static string ExtractText(string input)
        {
            if (input.Length == 0)
            {
                return "";
            }

            try
            {
                var list = input.Split("_");
                string val = "";

                if (list.Length > 2)
                {
                    val = list[2];
                }
                else
                {
                    val = input;
                }

                if (val.Length > 0)
                {
                    string text = val.Remove(0, 1);
                    return text;
                }

                return "";
            }
            catch (Exception ex)
            {
                throw new ExtractException(ex.ToString());
            }

            

        }
    }
}
