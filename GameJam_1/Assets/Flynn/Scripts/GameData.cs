using System.Collections.Generic;

[System.Serializable]
public class GameData 
{
    //public List<TMP> Text = new List<TMP>();
    public Offline Offline = new();
    public InfectableCountries InfectableCountries = new();
}
[System.Serializable]
public class Offline
{
    public int OfflineInt;
    public int Currency;
}
[System.Serializable]
public class InfectableCountries
{
    public List<Infected> Countries = new List<Infected>();
}
[System.Serializable]
public class R
{
    public int e;
    public int t;
    public string bla;
    public bool bas;
}
[System.Serializable]
public class Infected
{
    public string name;
    public float density;
    public bool isInfected;
}