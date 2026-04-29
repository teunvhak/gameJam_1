using UnityEngine;
using System;
using System.IO;

public static class SaveSystem 
{
    private static string PathForSave =>
   System.IO.Path.Combine(Application.persistentDataPath, "GameData.json");

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(PathForSave, json);
        Debug.Log($"Saved to: {PathForSave}");
    }
    public static GameData Load()
    {
        if (!File.Exists(PathForSave))
            return null;

        string json = File.ReadAllText(PathForSave);
        GameData data = JsonUtility.FromJson<GameData>(json);
        return data;
    }
    public static void DeleteSave()
    {
        if (File.Exists(PathForSave))
            File.Delete(PathForSave);
    }
}
