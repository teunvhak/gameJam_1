using System.Collections.Generic;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public class InfectionManager : MonoBehaviour
{
    public static InfectionManager Instance { get; private set; }

    public List<Infactable> Infectables = new List<Infactable>();
    public List<Infactable> Infected = new List<Infactable>();



    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);

        Infectables = new List<Infactable>(FindObjectsOfType<Infactable>());
    }

    private void Update()
    {
        foreach(var infection in Infectables)
        {
            if (TryInfect(infection))
            {
                infection.infectionDensity = Mathf.Clamp(infection.infectionDensity + 0.01f, 0f, 1f);
            }
        }
    }

    public bool TryInfect(Infactable infactable)
    {
        infactable.infectionChance = (infactable.infectionDensity / 10f) + 0.01f;
        float chance = Random.Range(0f, 1f);
        return chance <= infactable.infectionChance; 
    }
}
