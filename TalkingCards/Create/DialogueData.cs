﻿using System;
using System.Linq;
using InscryptionAPI.Helpers;

namespace TalkingCardAPI.TalkingCards.Create;

[Serializable]
public class DialogueEventStrings
{
    public string eventName { get; set; }
    public string[] mainLines { get; set; }
    public string[][] repeatLines { get; set; }

    public DialogueEventStrings(string eventName, string[] mainLines, string[][] repeatLines)
    {
        this.eventName = eventName;
        this.mainLines = mainLines;
        this.repeatLines = repeatLines;
    }

    public DialogueEvent CreateEvent(string cardName) => DialogueEventGenerator.GenerateEvent(
            $"{cardName}_{eventName}",
            mainLines.Select(x => (CustomLine)x).ToList(),
            repeatLines.Select(x => x.Select(y => (CustomLine)y).ToList()).ToList()
        );
}