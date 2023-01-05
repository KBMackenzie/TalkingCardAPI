﻿using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Helpers;

internal static class AssetHelpers
{
    private static readonly Dictionary<string, Texture2D> TextureCache = new();

    private static readonly Vector2 PIVOT_BOTTOM = new Vector2(0.5f, 0f);
    private static readonly Vector2 PIVOT_CENTER = new Vector2(0.5f, 0.5f);

    public static string? GetFile(string file) => Directory.GetFiles(Paths.PluginPath, file, SearchOption.AllDirectories).FirstOrDefault();

    public static Texture2D? MakeTexture(string? path)
    {
        if (path == null || path.IsWhiteSpace()) return null;
        
        if(TextureCache.ContainsKey(path))
        {
            //FileLog.Log($"Loading from cache: {path}");
            return TextureCache[path];
        }

        string? file = Path.IsPathRooted(path) ? path : GetFile(path);
        Texture2D? tex = file == null ? null : MakeTexture(File.ReadAllBytes(file));

        if (tex != null) TextureCache.Add(path, tex);
        return tex;
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
        Vector2 pivot = PIVOT_BOTTOM;
        return Sprite.Create(tex, texRect, pivot);
    }

    internal static Color32 HexToColor(string hex)
    {
        Queue<char> chars = new Queue<char>(hex.Trim());
        if (chars.Count == 0) return default;
        if (chars.Peek() == '#') chars.Dequeue();

        if (chars.Count < 6)
        {
            Plugin.LogError($"Invalid hexcode: {hex}");
            return Color.white;
        }

        // I could have used a List<byte>, but this is a tiny bit faster.
        // (And I know exactly how many items I'll need, anyway.)
        byte[] rgb = new byte[3];

        for (int i = 0; i < 3; i++)
        {
            StringBuilder sb = new();
            sb.Append(chars.Dequeue());
            sb.Append(chars.Dequeue());

            byte x = Convert.ToByte(sb.ToString(), 16);
            rgb[i] = x;
        }

        return new(rgb[0], rgb[1], rgb[2], 255);
    }
}