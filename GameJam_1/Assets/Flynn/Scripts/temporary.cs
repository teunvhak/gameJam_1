using UnityEngine;

public class temporary : MonoBehaviour
{
    void Start()
    {
        SaveManager.instance.Load();
        //SaveManager.instance.Data.InfectableCountries.Countries.Add(new Infected {});
        SaveManager.instance.Save(SaveManager.instance.Data);
    }
}
