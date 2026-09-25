public static class DialogTagParser 
{
    private const string DefaultString = "";
    private const string DefaultMood = "default";
    private const string DefaultSpeakerType = "system";
    private const string DefaultSpeakerCompoundKey = "system";

    private const int PrefixLengthLocalizationKey = 4; // loc:
    private const int PrefixLengthSpeaker = 4; // speaker:

    private static readonly char[] tagSeparator = { ':' };
    private static StringBuilder sb = new StringBuilder();

    public static DialogSerializableLine ParseLine(string textRaw, List<string> tags)
    {
        DialogSerializableLine line = new DialogSerializableLine 
        {
            TextRaw = textRaw,
            TextResolved = DefaultString,
            LocalizationKey = DefaultString,
            SpeakerData = new SpeakerData()
        }

        if (tags == null) return line;

        for (int i = 0, count = tags.Count; i < count; i++) 
        {
            string tag = tags[i];
            char firstChar = tag[0];
            if (firstChar == 'l') 
            {
                line.LocalizationKey = tag.Substring(PrefixLengthLocalizationKey);
            } 
            else if (firstChar == 's')
            {
                line.SpeakerData = ParseSpeakerData(tag.Substring(PrefixLengthSpeaker));
            }
        }
    }

    public static DialogSerializableChoice ParseChoice(string textRaw, List<string> tags)
    {
        DialogSerializableChoice choice = new DialogSerializableChoice 
        {
            TextRaw = textRaw,
            TextResolved = DefaultString,
            LocalizationKey = DefaultString
        }

        if (tags == null) return choice;

        for (int i = 0, count = tags.Count; i < count; i++) 
        {
            string tag = tags[i];
            char firstChar = tag[0];
            if (firstChar == 'l') 
            {
                choice.LocalizationKey = tag.Substring(PrefixLengthLocalizationKey);
            }
        }
    }

    private static SpeakerData ParseSpeakerData(string stringValue) 
    {
        var parts = stringValue.Split(tagSeparator);
        return new SpeakerData
        {
            SpeakerType = parts.Length > 0 ? parts[0] : DefaultSpeakerType,
            SpeakerId = parts.Length > 1 ? parts[1] : DefaultString,
            Mood = parts.Length > 2 ? parts[2] : DefaultMood,
            CompoundKey = stringValue,
        }
    }
}
