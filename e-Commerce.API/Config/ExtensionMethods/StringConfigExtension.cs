using System.Text.RegularExpressions;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class StringExtension
    {
        public static string SepararPalavraPorMaiusculas(this string palavra)
        {
            string regex = @"([A-Z][a-z]*)";

            MatchCollection matches = Regex.Matches(palavra, regex);

            string separador = "";

            foreach (Match m in matches)
            {
                separador += m.Value + " ";
            }

            return separador;
        }
    }
}
