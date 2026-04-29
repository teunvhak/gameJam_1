using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    public GameData Data { get; private set; }

    public void Awake()
    {
        if (instance == null)
        { instance = this; }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Load();
    }
    public void Save(GameData data)
    {
        SaveSystem.Save(data);
    }
    public void Load()
    {
        Data = SaveSystem.Load() ?? new GameData();
    }
    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
        Data = new GameData { };
    }
}
