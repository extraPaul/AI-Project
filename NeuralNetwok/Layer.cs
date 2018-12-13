using System;

namespace NeuralNetwok
{   [Serializable]
	public class Layer
	{
		/// <summary>
        /// Stores array of neurons in a layer
        /// </summary>
        public Neuron[] neurons { get; set; }
        /// <summary>
        /// Number of neurons in layer
        /// </summary>
		public int size { get; set; }
        /// <summary>
        /// Number of inputs to layer or alternatively number of neurons in previous layer
        /// </summary>
		public int inputSize { get; set; }

        /// <summary>
        /// Represents a layer in the neural network
        /// </summary>
        /// <param name="size">Number of neurons in layer</param>
        /// <param name="inputSize">Number of inputs to layer or alternatively number of neurons in previous layer</param>
		public Layer(int size, int inputSize)
		{
			this.size = size;
			this.inputSize = inputSize;
			neurons = new Neuron[size];
			for (int i = 0; i < size; i++)
			{
				neurons[i] = new Neuron(inputSize);
			}
		}
        
        public Layer()
        {

        }

        /// <summary>
        /// Returns array of the output of each individual neuron
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public float[] output(float[] input)
		{
			var outputs = new float[size];
			for (int i = 0; i < size; i++)
			{
				outputs[i] = neurons[i].output(input);
			}
			return outputs;
		}
	}
}

