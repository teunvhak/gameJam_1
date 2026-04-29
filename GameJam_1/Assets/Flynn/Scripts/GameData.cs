using System.Collections.Generic;

[System.Serializable]
public class GameData 
{
    //public List<TMP> Text = new List<TMP>();
    public TMP Text = new();
    public TMP1 Text1 = new();
}
[System.Serializable]
public class TMP
{
    public int TMPInt;
    public float TMPFloat;
}
[System.Serializable]
public class TMP1
{
    public int TMPInt;
    public float TMPFloat;
}