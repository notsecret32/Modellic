using System;

namespace Modellic.Enums
{
    public enum SwSupportedLanguages
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

    public static class SwSupportedLanguagesParser
    {
        public static SwSupportedLanguages Parse(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
            {
                throw new ArgumentException("Строка языка не может быть null или пустой.", nameof(language));
            }

            var normalized = language.Trim().ToLowerInvariant();

            return normalized switch
            {
                "chinese" => SwSupportedLanguages.Chinese,
                "chinese-simplified" => SwSupportedLanguages.ChineseSimplified,
                "czech" => SwSupportedLanguages.Czech,
                "english" => SwSupportedLanguages.English,
                "french" => SwSupportedLanguages.French,
                "german" => SwSupportedLanguages.German,
                "italian" => SwSupportedLanguages.Italian,
                "japanese" => SwSupportedLanguages.Japanese,
                "korean" => SwSupportedLanguages.Korean,
                "polish" => SwSupportedLanguages.Polish,
                "portuguese-brazilian" => SwSupportedLanguages.PortugueseBrazilian,
                "russian" => SwSupportedLanguages.Russian,
                "spanish" => SwSupportedLanguages.Spanish,
                "turkish" => SwSupportedLanguages.Turkish,
                _ => throw new ArgumentException($"Неподдерживаемый язык: {language}", nameof(language))
            };
        }
    }
}
