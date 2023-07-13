using System.Collections.Generic;
using Project.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeuronGenerator : MonoBehaviour
{
    [SerializeField] private GameObject neuronCompartmentPrefab;
    [SerializeField] private GameObject neuronParent;
    [SerializeField] private GameObject player;
    private readonly NeuronRepository _repository = new();
    private TMP_Dropdown _dropdown;

    void Start()
    {
        InitializeDropdown();
    }

    private void InitializeDropdown()
    {
        _dropdown = gameObject.GetComponent<TMP_Dropdown>();
        _dropdown.options = new List<TMP_Dropdown.OptionData>();
        var neuronList = _repository.GetNeuronList();
        foreach (var neuron in neuronList)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData {text = $"{neuron}.swc"});
            _dropdown.RefreshShownValue();
        }
    }

    public void OnSelectedDropdown()
    {
        DestroyNeuron();
        var neuron = _repository.GetNeuron(_dropdown.options[_dropdown.value].text);
        RenderingNeuron(neuron);
        NeuronCompartment cellBody = neuron.GetCellBody();
        if (cellBody == null) return;
        player.transform.position = new Vector3(cellBody.PositionX, cellBody.PositionY, cellBody.PositionZ - 100.0f);
    }

    private void RenderingNeuron(Neuron neuron)
    {
        foreach (var nc in neuron.Compartments.Values)
        {
            Vector3 position = new Vector3(nc.PositionX, nc.PositionY, nc.PositionZ);

            GameObject neuronCompartmentObj = Instantiate(neuronCompartmentPrefab, position, Quaternion.identity);

            neuronCompartmentObj.transform.parent = neuronParent.gameObject.transform;
            neuronCompartmentObj.transform.localScale = new Vector3(nc.Radius, nc.Radius, nc.Radius);
            neuronCompartmentObj.GetComponent<Renderer>().material.color = Color.red;

            NeuronCompartment parent;
            if (!neuron.Compartments.TryGetValue(nc.ParentId, out parent)) continue;

            var lineRenderer = neuronCompartmentObj.GetComponent<LineRenderer>();
            lineRenderer.SetPositions(new[] {position, new(parent.PositionX, parent.PositionY, parent.PositionZ)});
            lineRenderer.startWidth = nc.Radius;
            lineRenderer.endWidth = nc.Radius;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = new Color(1.0f, 0.3f, 0.25f);
            lineRenderer.endColor = new Color(1.0f, 0.3f, 0.25f);
        }
    }

    private void DestroyNeuron()
    {
        for (int i = 0; i < neuronParent.transform.childCount; i++)
        {
            Destroy(neuronParent.transform.GetChild(i).gameObject);
        }
    }
}