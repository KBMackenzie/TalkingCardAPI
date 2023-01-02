using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingCardAPI.TalkingCards.Helpers;

// This is so I don't have to repeat myself making 232903902 dictionaries for enums.
// It creates a Dictionary<string, EnumValue> on its own.
// The keys are also not case-sensitive, as I think that'd be important.
internal class EnumDictionary<T> where T : Enum
{
    private readonly Dictionary<string, T> _enumValues = new();
    public int Count => _enumValues.Count;

    public EnumDictionary()
    {
        CreateDictionary();
    }

    private void CreateDictionary()
    {
        string[] names = Enum.GetNames(typeof(T));
        T[]? values = Enum.GetValues(typeof(T)) as T[];

        if (values == null) return;

        for (int i = 0; i < names.Length; i++)
        {
            // ToLower() is so it'll be more forgiving.
            // JSON users can be bad with capitalization, after all.

            _enumValues.Add(names[i].ToLower(), values[i]);
        }
    }

    public T? Get(string? key)
    {
        key = key?.Trim()?.ToLower() ?? string.Empty;

        return _enumValues.ContainsKey(key)
            ? _enumValues[key]
            : default;
    }
}

