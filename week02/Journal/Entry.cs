using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string prompt, string response, string mood)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public string GetDisplayText()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nMood: {_mood}\nResponse: {_response}\n";
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_prompt}|{_response}|{_mood}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        string mood = parts.Length > 3 ? parts[3] : "Unknown";
        return new Entry(parts[1], parts[2], mood) { _date = parts[0] };
    }
}
