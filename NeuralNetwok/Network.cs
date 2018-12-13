using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace NeuralNetwok
{
	[Serializable]
	public class Network
	{
        /// <summary>
        /// Weight learning rate(arbitrary constant)
        /// </summary
		public float nabla;
        /// <summary>
        /// Bias learning rate(arbitrary constant)
        /// </summary>
      
        public float gamma;

        /// <summary>
        /// Array of layers that the neural netwrok is composed of.
        /// Each layers contains one or multiple neurons.
        /// </summary>
     
        public Layer[] layers;

        /// <summary>
        /// Initializes network. nodes[0] is number of inputs to network, nodes[nodes.count -1] is number of output
		/// neurons. Each element in between is the number of neurons in that repective layer. Ex : [1,2,3,1] will
		/// generate a network with one input, a hidden layer with 2 neurons, a hidden layer with 3 neurons and 1
		/// output neuron.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="weightAdapt"></param>
        /// <param name="biasAdapt"></param>
		//
		public Network(int[] nodes, float weightAdapt, float biasAdapt)
		{
			layers = new Layer[nodes.Length-1];
			for (int i = 1; i < nodes.Length; i++)
			{
				layers[i-1] = new Layer(nodes[i], nodes[i - 1]);
			}
			nabla = weightAdapt;
			gamma = biasAdapt;
		}

        public Network() { }

        /// <summary>
        /// Passes input through neural net to get output.
		/// The output of each layer is fed as input to next layer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public float[] feedForward(float[] input)
		{
			var output = layers[0].output(input);
			for (int i = 1; i < layers.Length; i++) //skip input layer
			{
				output = layers[i].output(output);
			}
			return output;
		}

        /// <summary>
        /// Uses backpropagation algorithm to determine variation of weights and biases
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
		public void learn(float[] input, float[] expected)
		{
			var delta = new List<float[]>();
			delta.Add(calcError(input, expected));
			for (int i = 1; i < layers.Length; i++)
			{
				delta.Add(layerDelta(layers[layers.Length - i], delta[delta.Count - 1], layers[layers.Length - i - 1]));
			}
            delta.Reverse();
            backPropagate(delta.ToArray());
		}

		private void backPropagate(float[][] deltas)
		{
			for (int i = 0; i < layers.Length; i++) // iterate of each layer
			{
				for (int j = 0; j < layers[i].size; j++) // iterate over each neuron in ith layer
				{
					// adjusts weights of jth neuron in ith layer using its repective delta,
					//learning rates and gradient descent
					layers[i].neurons[j].gradientDescent(deltas[i][j], nabla, gamma);
				}
			}

		}

        /// <summary>
        /// Calculates deltas in a layer if delta of next layer is known. propagates
		/// from the output layer inwards
        /// </summary>
        /// <param name="known"></param>
        /// <param name="knownDelta"></param>
        /// <param name="computed"></param>
        /// <returns></returns>
		private float[] layerDelta(Layer known, float[] knownDelta, Layer computed)
		{
			var computedDelta = new float[computed.size];
			float temp;

			// iterates over each neuron in computed layer, the layer who's delta
			//is unkown and is being calculated
			for (int i = 0; i < computed.size; i++)
			{
				temp = 0;
				// calculates delta of ith neuron in the computed layer
				for (int j = 0; j < known.size; j++)
				{
					temp += known.neurons[j].weight(i) * knownDelta[j];
				}
				computedDelta[i] = temp;
			}
			// returns deltas of the computed layer
			return computedDelta;
		}

        /// <summary>
        /// Error function of output layer, calculates the delta
		/// of output layer to allow backpropagation
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
		public float[] calcError(float[] input, float[] expected)
		{
			var output = feedForward(input);
			var errors = new float[output.Length];
			//Cross entropy error function
			for (int i = 0; i < output.Length; i++)
			{
				errors[i] = expected[i] - output[i];
			}
			return errors;
		}

        public void Save(Stream stream)
        {
            XmlSerializer xmlS = new XmlSerializer(this.GetType());
            Network n = new Network();
            n.gamma = this.gamma;
            n.layers = new Layer[this.layers.Length];
            n.nabla = this.nabla;
            for(int i =0; i<this.layers.Length; i++)
            {
                n.layers[i] = new Layer();
                n.layers[i].size = this.layers[i].size;
                n.layers[i].inputSize = this.layers[i].inputSize;
                n.layers[i].neurons = new Neuron[this.layers[i].neurons.Length];
                for (int j = 0; j < n.layers[i].neurons.Length; j++)
                {
                    n.layers[i].neurons[j] = new Neuron();
                    n.layers[i].neurons[j].bias = this.layers[i].neurons[j].bias;
                    n.layers[i].neurons[j].weights = this.layers[i].neurons[j].weights;
                }
            }
            xmlS.Serialize(stream, n);
        }

        public void Load(Stream stream)
        {
            XmlSerializer xmlS = new XmlSerializer(this.GetType());
            Network n = (Network)xmlS.Deserialize(stream);
            this.gamma = n.gamma;
            this.layers = new Layer[n.layers.Length];
            this.nabla = n.nabla;
            for (int i = 0; i < this.layers.Length; i++)
            {
                this.layers[i] = new Layer();
                this.layers[i].size = n.layers[i].size;
                this.layers[i].inputSize = n.layers[i].inputSize;
                this.layers[i].neurons = new Neuron[n.layers[i].neurons.Length];
                for (int j = 0; j < this.layers[i].neurons.Length; j++)
                {
                    this.layers[i].neurons[j] = new Neuron();
                    this.layers[i].neurons[j].bias = n.layers[i].neurons[j].bias;
                    this.layers[i].neurons[j].weights = n.layers[i].neurons[j].weights;
                }
            }

        }
    }
}

