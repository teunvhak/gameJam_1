using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public static Currency instance;

    public int currency;
    public TextMeshProUGUI currencyText;

    public int currencyMultiplier = 1;
    public float totalDensity = 0f;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }    

    private void Start()
    {
        SaveManager.instance.Load();
        currency = SaveManager.instance.Data.Offline.Currency;
        UpdateVisual();
    }

    private void Update()
    {
        var data = SaveManager.instance.Data.InfectableCountries;

        currencyMultiplier = 1;
        totalDensity = 0f;

        foreach (var country in data.Countries)
        {
            totalDensity += country.density;
            if (country.isInfected)
            {
                currencyMultiplier++;
            }
        }

        currency += Mathf.Max(1, (int)(totalDensity * currencyMultiplier)) / 10;

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        currencyText.text = "Currency: " + currency;
        SaveManager.instance.Data.Offline.Currency = currency;
        SaveManager.instance.Save(SaveManager.instance.Data);
    }
}
