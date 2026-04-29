using UnityEngine;

public class Infactable : MonoBehaviour
{
    public bool IsInfected = false;

    [Range(0, 1)] public float infectionDensity;
    [Range(0, 1)] public float infectionChance;


    private void Update()
    {
        if(infectionDensity >= 1f) IsInfected = true;

        if (IsInfected && !InfectionManager.Instance.Infected.Contains(this))
            InfectionManager.Instance.Infected.Add(this);
    }
}
