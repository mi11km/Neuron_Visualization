using Project.Scripts;
using UnityEngine;

public class NeuronGenerator : MonoBehaviour
{
    [SerializeField] private GameObject neuronCompartmentPrefab;
    [SerializeField] private GameObject neuronParent;
    private readonly NeuronRepository _repository = new();

    // Start is called before the first frame update
    void Start()
    {
        RenderingNeuron(_repository.GetNeuron());
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
}