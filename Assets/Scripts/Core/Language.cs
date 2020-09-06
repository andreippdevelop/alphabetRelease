[System.Serializable]
public class Language
{
    public enum LanguageType
    {
        Alphabet,
        English,
        Russian,
        Ukraine
    }

    private static string _alphabet = "Alphabet";
    private static string _englishTypeText = "English";
    private static string _russianTypeText = "Russian";
    private static string _ukraineTypeText = "Ukraine";

    public static string GetLanguageTextValue(LanguageType type)
    {
        string textValue = _englishTypeText;

        switch(type)
        {
            case LanguageType.Alphabet:
                textValue = _alphabet;
                break;
            case LanguageType.English:
                textValue = _englishTypeText;
                break;
            case LanguageType.Russian:
                textValue = _russianTypeText;
                break;
            case LanguageType.Ukraine:
                textValue = _ukraineTypeText;
                break;
        }

        return textValue;
    }
}
