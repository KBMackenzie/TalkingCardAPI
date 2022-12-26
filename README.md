An Inscryption mod that lets you easily add talking cards with an animated portrait and dialogue all with a JSON file.

![Talking Card Example](https://i.imgur.com/KRDrMOM.gif)

This mod is currently in its **beta** stage. There might be bugs. If you have trouble using this mod, please read the [FAQ](#FAQ)! And if the FAQ doesn't help you or your bug isn't mentioned in the FAQ at all, feel free to contact me on Discord: `kelly betty#7936`

# Installation
This mod’s only dependencies are BepInEx and the InscryptionAPI mod.

There are two ways of installing this mod: with the help of a mod manager (like r2modman or the Thunderstore Mod Manager) or manually.

#### Installation (Mod Manager)
1. Download and install [r2modman](https://thunderstore.io/package/ebkr/r2modman/) or the [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager).
2. Install this mod and all of its dependencies with the help of the mod manager! 

#### Installation (Manual)
1. Download and install BepInEx.
    1. If you're downloading it from [its Github page](https://github.com/BepInEx/BepInEx/releases), follow [this installation guide](https://docs.bepinex.dev/articles/user_guide/installation/index.html#where-to-download-bepinex).
    2. If you're downloading ["BepInExPack Inscryption" from Thunderstore](https://inscryption.thunderstore.io/package/BepInEx/BepInExPack_Inscryption/), follow the manual installation guide on the Thunderstore page itself. This one comes with a preconfigured `BepInEx.cfg` file, so it's advised.
3. Download and install the [Inscryption API mod](https://inscryption.thunderstore.io/package/API_dev/API/) following its manual installation guide.
4. Find the `BepInEx > plugins` folder.
5. Place the contents of **"TalkingCardAPI.zip"** in a new folder within the plugins folder.


# The JSON File
Your JSON file for this mod **must have a name that ends in "\_talk.json"**. If your JSON file's name does not end in "\_talk.json", this mod will not find your file.

If you're using this mod, I **heavily encourage you** to use [this JSON Generator](https://json-editor.github.io/json-editor/?data=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) for making your JSON file. I wrote the schema for this generator myself, making sure to add as many descriptions and as much pattern-matching as I could to make the process easier for you.

Again, **I heavily encourage you** to use this JSON Generator: [link](https://json-editor.github.io/json-editor/?data=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).

Anyhow; the documentation.

Your JSON file should look like this:

```json
{
  "cardName": "",
  "faceSprite": "",
  "eyeSprites": {
    "open": "",
    "closed": ""
  },
  "mouthSprites": {
    "open": "",
    "closed": ""
  },
  "emissionSprite": "",
  "faceInfo": {
    "blinkRate": 1.5,
    "voiceId": "female1_voice",
    "voiceSoundPitch": 1,
    "customVoice": ""
  },
  "dialogueEvents": [
    {
      "eventName": "OnDrawn",
      "mainLines": [ "" ],
      "repeatLines": [
        [ "" ],
        [ "" ]
      ]
    }
  ]
}
```

I'm going to explain each field in detail below.

If you want to see an example of a \_talk.json file completed filled out, you can look at my [Talking Possum](https://github.com/KBMackenzie/InscryptionJSONDump/blob/main/TalkingPossum/JSON/Possum_talk.json) card.

### Overview

| Field          | Description                                                                  |
|----------------|------------------------------------------------------------------------------|
| cardName       | The name of an existing card.                                                |
| faceSprite     | The path to an image for your card's face.                                   |
| eyeSprites     | The path to the images for your card's eyes: open and closed, respectively.  |
| mouthSprites   | The path to the images for your card's mouth: open and closed, respectively. |
| emissionSprite | The path to an image for your card's eye emission.                           |
| faceInfo       | A bunch of details about your card, which will be explained below.           |
| dialogueEvents | The dialogue for your card. Will be explained more in depth below.           |

### Sprite Images
The images used for the character's face should have the dimensions of a regular Inscryption Act 1 card portrait: That is, 114 x 94 pixels.

A good approach to making these face sprites is draw the face, eyes and mouth in different layers in your art program of choice and then exporting each layer separately!

### FaceInfo

| Field          | Description                                                                  |
|----------------|------------------------------------------------------------------------------|
| blinkRate      | How often your character blinks. The higher, the more often they'll blink.   |
| voiceId        | Your character's "voice". Will explain more below.                           |
| voiceSondPitch | Your character's voice's pitch. The higher the number, the higher the pitch. |
| customVoice    | A custom voice for your character. Will be explained below.                  |

"voiceId" can only be one of these three strings:
1. female1_voice
2. cat_voice
3. kobold_voice

Most talking cards in the game use the first and simply change the pitch.

#### Custom Voices
You can add a custom voice to your character instead of using one of the default voices. For that, all you need to is put the path to your audio file in the "customVoice" field.

The supported audio formats are MP3, WAV, OGG and AIFF!

Please use a very short audio file for your voice. Typically, you want only a very short 'vowel' sound for this, since it's going to be played in rapid repetition.

If you put anything in "customVoice", then the contents of the "voiceId" field will not matter.

### DialogueEvents

The "dialogueEvents" field is an array of dialogue event objects. If you're confused by this, you should use the generator I mentioned above: it makes this step much easier.

A dialogue event object has the following fields for you to fill:

| Field       | Description                                                                 |
|-------------|-----------------------------------------------------------------------------|
| eventName   | The "trigger" for this dialogue event.                                      |
| mainLines   | The main lines for your dialogue event: what is said when it first happens. |
| repeatLines | The lines to be repeated when this event plays a second, and so on.         |

The "eventName" field can have the following strings for triggers:

| Trigger                    | Description                                                    |
|----------------------------|----------------------------------------------------------------|
| OnDrawn                    | Plays when your card is drawn.                                 |
| OnPlayFromHand             | Plays when your card is played.                                |
| OnAttacked                 | Plays when your card is attacked.                              |
| OnBecomeSelectablePositive | Plays when your card becomes selectable for a positive effect. |
| OnBecomeSelectableNegative | Plays when your card becomes selectable for a negative effect. |
| OnSacrificed               | Plays when your card is sacrificed.                            |
| OnSelectedForDeckTrial     | Plays when your card is selected in the deck trial node.       |
| OnSelectedForCardMerge     | Plays when your card is selected in the sigil (?) node.        |
| OnSelectedForCardRemove    | Plays when your card is selected for removal.                  |
| OnDiscoveredInExploration  | ... I'm unsure about this one, actually.                       |
| ProspectorBoss             | Plays at the beginning of the Prospector fight.                |
| AnglerBoss                 | Plays at the beginning of the Angler fight.                    |
| TrapperTraderBoss          | Plays at the beginning of the Trapper/Trader fight.            |
| LeshyBoss                  | Plays at the beginning of Leshy's boss fight.                  |
| RoyalBoss                  | Plays at the beginning of Royal's boss fight.                  |
| DefaultOpponent            | I am... unsure if this one even works.                         |

# Dialogue Codes
A really neat feature of Inscryption's dialogue events are dialogue codes, which have many uses in dialogue.

The dialogue codes most relevant to talking cards will be explained below. All of these work with talking cards.

### Wait (\[w:])
This is by far the dialogue code you'll wanna use the most. It's also the one the game itself uses the most in all of its dialogue.

The "\[w:x]" dialogue code adds a pause of x seconds before the rest of a sentence plays.

You can use it like this:
```
"Hello.[w:1] How are you?"
```
In this example, after saying "Hello.", the character waits 1 second before saying "How are you?".

The number of seconds does not have to be an integer. Using "\[w:0.2]" to wait only 0.2 seconds is valid, for example, and used often throughout the base game's dialogue.

This being said, I'd advise you not to go below \[w:0.1], as I don't know how small the number can go before issues arise. (And there's no point in going below that, anyhow.)

### Color (\[c:])
The \[c:] dialogue code changes the color of a portion of your text.

You can use it like this:
```
"[c:R]This text is red.[c:] This text is not."
```
In this example, the part after \[c:R] is colored in the color that matches the code 'R', which is the color red, and the part after \[c:] has the default text color. You can think of this as "switching on" the colorful text mode and then switching it off.

*"But how do I know the codes for each color?"*
Fear not! Here's a comprehensive table of all available colors and their respective codes:

| Code | Color             |
|------|-------------------|
| B    | Blue              |
| bB   | Bright Blue       |
| bG   | Bright Gold       |
| blGr | Bright Lime Green |
| bR   | Bright Red        |
| brnO | Brown Orange      |
| dB   | Dark Blue         |
| dlGr | Dark Lime Green   |
| dSG  | Dark Seafoam      |
| bSG  | Glow Seafoam      |
| G    | Gold              |
| gray | Gray              |
| lGr  | Lime Green        |
| O    | Orange            |
| R    | Red               |

(For the record: These are the colors the game has available, built-in. I did not choose them. Yes, it's a very odd selection of colors.)

#### Custom Colors
I have added a way to use custom colors with dialogue codes. In place of one of the color codes in the table above, you can instead use a [hex color code](https://htmlcolorcodes.com/color-picker/), and this mod will parse the code into an usable Color for the text.

Here's an example:
```
"You must be... [w:0.4][c:#7f35e6]confused[c:][w:1].",
```
In this example, the word "confused" is colored in the color #7f35e6. Which, if you don't wanna look it up, is [this color!](https://g.co/kgs/JPHV5v)

### Leshy (\[leshy:x])
The \[leshy:x] dialogue code makes Leshy say x. This color code is very useful for making Leshy and your card talk a bit between each other!

You can use it like this:

```
"We're all doomed.[leshy:Quiet now.][w:2]",
```
In this example, the character says "We're all doomed." and then Leshy says "Quiet now." right after. The text remains on the screen for 2 seconds.

There are a few things to note from that example:

1. You don't need to put quotation marks around the line Leshy is going to say.
2. The "Wait" dialogue code is still usable with Leshy's lines.

# FAQ

**Q:** *"I'm getting an error that says my \_talk.json file couldn't be loaded! What does this mean?"

**A:** Please double check your file and make sure you didn't make any mistakes with the JSON syntax.

There are multiple JSON validator tools you can use online that catch syntax errors and things of the sort. A favorite of mine is [JSONLint](https://jsonlint.com/).

# Special Thanks
Special thanks to Nevernamed (Bt Y#0895) on Discord for his help with setting up talking cards! c:

# Credits
This project uses [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) for parsing JSON data.

Newtonsoft.Json's license can be found [here](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md).