using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronCompartmentPrefab : MonoBehaviour
{
    public void Stimulate()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void ToDefaultPotential()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}