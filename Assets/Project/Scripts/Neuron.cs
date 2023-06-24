using System.Collections.Generic;

namespace Project.Scripts
{
    public class Neuron
    {
        public readonly Dictionary<int, NeuronCompartment> Compartments;

        public Neuron()
        {
            Compartments = new Dictionary<int, NeuronCompartment>();
        }
    }

    public class NeuronCompartment
    {
        public readonly int ID;
        public readonly int Type;
        public readonly float PositionX;
        public readonly float PositionY;
        public readonly float PositionZ;
        public readonly float Radius;
        public readonly int ParentId;

        public NeuronCompartment(int id, int type, float positionX, float positionY, float positionZ, float radius,
            int parentId)
        {
            ID = id;
            Type = type;
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
            Radius = radius;
            ParentId = parentId;
        }
    }
}