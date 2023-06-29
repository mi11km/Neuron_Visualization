using System.Collections.Generic;
using Project.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeuronGenerator : MonoBehaviour
{
    [SerializeField] private GameObject neuronCompartmentPrefab;
    [SerializeField] private GameObject neuronParent;
    private readonly NeuronRepository _repository = new();

    private readonly string[] _neuronList = {"a1247", "a1531", "a1963", "a2191", "a3783", "pkj1599",};
    private TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _dropdown = gameObject.GetComponent<TMP_Dropdown>();
        _dropdown.options = new List<TMP_Dropdown.OptionData>();
        foreach (var neuron in _neuronList)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData {text = $"{neuron}.swc"});
            _dropdown.RefreshShownValue();
        }
    }

    public void OnSelectedDropdown()
    {
        DestroyNeuron();
        RenderingNeuron(_repository.GetNeuron(_dropdown.options[_dropdown.value].text));
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

            var lineRenderer = neuronCompartmentObj.AddComponent<LineRenderer>();
            lineRenderer.SetPositions(new[] {position, new(parent.PositionX, parent.PositionY, parent.PositionZ)});
            lineRenderer.startWidth = nc.Radius;
            lineRenderer.endWidth = parent.Radius;
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