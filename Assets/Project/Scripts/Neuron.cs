using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Project.Scripts
{
    public class Neuron
    {
        public Dictionary<int, NeuronCompartment> compartments;

        public Neuron()
        {
            compartments = new Dictionary<int, NeuronCompartment>();
        }

        public void Parse(string swcData)
        {
            string[] lines = swcData.Split("\n");
            foreach (string line in lines)
            {
                try
                {
                    var neuronCompartment = NeuronCompartment.Parse(line);
                    compartments.Add(neuronCompartment.id, neuronCompartment);
                }
                catch (NeuronParseException e)
                {
                    Debug.Log(line);
                }
            }
        }
    }

    public class NeuronCompartment
    {
        public int id;
        public int type;
        public float positionX;
        public float positionY;
        public float positionZ;
        public float radius;
        public int parentId;

        public NeuronCompartment(int id, int type, float positionX, float positionY, float positionZ, float radius,
            int parentId)
        {
            this.id = id;
            this.type = type;
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.radius = radius;
            this.parentId = parentId;
        }

        static public NeuronCompartment Parse(string data)
        {
            if (!Regex.IsMatch(data, @"^(\d+\s+){2}(-?\d+\.\d+\s+){4}-?\d+\s*$"))
            {
                throw new NeuronParseException("");
            }

            string[] compartmentDetail = data.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return new NeuronCompartment(Int32.Parse(compartmentDetail[0]), Int32.Parse(compartmentDetail[1]),
                float.Parse(compartmentDetail[2]), float.Parse(compartmentDetail[3]), float.Parse(compartmentDetail[4]),
                float.Parse(compartmentDetail[5]), Int32.Parse(compartmentDetail[6]));
        }
    }

    class NeuronParseException : Exception
    {
        public NeuronParseException(string message)
        {
        }
    }
}