using System;

namespace Modellic.App.Enums
{
    /// <summary>
    /// Список поддерживаемых языков в SolidWorks.
    /// </summary>
    public enum SwSupportedLanguage
    {
        Chinese,
        ChineseSimplified,
        Czech,
        English,
        French,
        German,
        Italian,
        Japanese,
        Korean,
        Polish,
        PortugueseBrazilian,
        Russian,
        Spanish,
        Turkish
    }

    public static class SwSupportedLanguageParser
    {
        public static SwSupportedLanguage Parse(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
            {
                throw new ArgumentException("Строка языка не может быть null или пустой.", nameof(language));
            }

            var normalized = language.Trim().ToLowerInvariant();

            return normalized switch
            {
                "chinese" => SwSupportedLanguage.Chinese,
                "chinese-simplified" => SwSupportedLanguage.ChineseSimplified,
                "czech" => SwSupportedLanguage.Czech,
                "english" => SwSupportedLanguage.English,
                "french" => SwSupportedLanguage.French,
                "german" => SwSupportedLanguage.German,
                "italian" => SwSupportedLanguage.Italian,
                "japanese" => SwSupportedLanguage.Japanese,
                "korean" => SwSupportedLanguage.Korean,
                "polish" => SwSupportedLanguage.Polish,
                "portuguese-brazilian" => SwSupportedLanguage.PortugueseBrazilian,
                "russian" => SwSupportedLanguage.Russian,
                "spanish" => SwSupportedLanguage.Spanish,
                "turkish" => SwSupportedLanguage.Turkish,
                _ => throw new ArgumentException($"Неподдерживаемый язык: {language}", nameof(language))
            };
        }
    }
}
