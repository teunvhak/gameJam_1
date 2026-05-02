using System.Collections.Generic;
using UnityEngine;

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
        Infect();
    }
    public void Infect()
    {
        foreach (var infection in Infectables)
        {
            if (TryInfect(infection))
            {
                infection.infectionDensity = Mathf.Clamp(infection.infectionDensity + 0.01f, 0f, 1f);
            }
        }

        foreach (var infected in Infected)
        {
            foreach (var infactable in Infectables)
            {
                float distance = Vector3.Distance(infected.transform.position, infactable.transform.position);
                if (distance <= 2.5f || (infected.HasHarbour && infactable.HasHarbour) || (infected.HasAirport && infactable.HasAirport))
                {
                    if (!infected.Neighbours.Contains(infactable))
                    {
                        infected.Neighbours.Add(infactable);
                        foreach (var neighbour in infected.Neighbours)
                        {
                            if (!neighbour.Neighbours.Contains(neighbour))
                            {
                                neighbour.Neighbours.Add(neighbour);
                            }
                        }
                    }
                }
            }
        }
    }

    public bool TryInfect(Infactable infactable)
    {
        infactable.infectionChance = (infactable.infectionDensity / 10f) + infactable.neighbourInfectionDensity;
        float chance = Random.Range(0f, 1f);
        return chance <= infactable.infectionChance; 
    }
}
