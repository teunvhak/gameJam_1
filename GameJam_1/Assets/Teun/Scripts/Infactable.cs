using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public class Infactable : MonoBehaviour
{
    [Tooltip("if this becomes true the infection will start spreading to the neighbours")]
    public bool IsInfected = false;

    [Tooltip("to start the infection put this to a very low value like 0.01")]
    [Range(0, 1)] public float infectionDensity;
    [Range(0, 1)] public float infectionChance;

    [HideInInspector]
    public List<Infactable> Neighbours = new List<Infactable>();
    [HideInInspector]
    public float neighbourInfectionDensity;
    private List<Infactable> countedNeighbours = new List<Infactable>();

    public bool HasHarbour = false;
    public bool HasAirport = false;
    [Tooltip("this is a bool that will be toggled if the research is done, for in the future")]
    public bool HarbourResearch = true;
    public bool AirportResearch = true;


    private void Update()
    {
        if (infectionDensity == 1f)
        {
            IsInfected = true;
            GetComponent<Renderer>().material.color = Color.green;
        }

        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, infectionDensity);

        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).tag == "Harbour" && HarbourResearch)
            {
                HasHarbour = true;
            }
            if (transform.GetChild(0).tag == "Airport" && AirportResearch)
            {
                HasAirport = true;
            }
        }

        if (IsInfected && !InfectionManager.Instance.Infected.Contains(this))
            InfectionManager.Instance.Infected.Add(this);

        foreach (var neighbour in Neighbours)
        {
            if (!countedNeighbours.Contains(neighbour))
            {
                neighbour.neighbourInfectionDensity += infectionDensity / 15;
                countedNeighbours.Add(neighbour);
            }
        }
    }
}
