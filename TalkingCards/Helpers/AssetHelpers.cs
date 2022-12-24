using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Helpers;

internal static class AssetHelpers
{
    public static string? GetFile(string file) => Directory.GetFiles(Paths.PluginPath, file, SearchOption.AllDirectories).FirstOrDefault();

    public static Texture2D? MakeTexture(string? path)
    {
        if (path == null) return null;
        string? file = Path.IsPathRooted(path) ? path : GetFile(path);
        return file == null ? null : MakeTexture(File.ReadAllBytes(file));
    }

    public static Texture2D MakeTexture(byte[] data)
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(data);
        tex.filterMode = FilterMode.Point;
        return tex;
    }

    public static Sprite? MakeSprite(string? path)
    {
        Texture2D? tex = MakeTexture(path);
        return tex == null ? null : MakeSprite(tex);
    }

    public static Sprite MakeSprite(byte[] data)
    {
        return MakeSprite(MakeTexture(data));
    }

    public static Sprite MakeSprite(Texture2D tex)
    {
        Rect texRect = new Rect(0, 0, tex.width, tex.height);
        Vector2 pivot = new Vector2(0.5f, 0f);
        return Sprite.Create(tex, texRect, pivot);
    }
}