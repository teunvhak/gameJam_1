using UnityEngine;

public class temporary : MonoBehaviour
{
    void Start()
    {
        SaveManager.instance.Load();
        SaveManager.instance.Data.Text.TMPFloat++;
        SaveManager.instance.Data.Text.TMPInt++;
        SaveManager.instance.Data.Text1.TMPFloat++;
        SaveManager.instance.Data.Text1.TMPInt++;
        SaveManager.instance.Save(SaveManager.instance.Data);
    }
}
