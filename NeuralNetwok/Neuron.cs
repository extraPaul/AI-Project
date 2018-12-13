using System;

namespace NeuralNetwok
{   [Serializable]
	public class Neuron
	{
        /// <summary>
        /// Weights for weighted sum of inputs
        /// </summary>
		public float[] weights { get; set; }
        /// <summary>
        /// number of inputs
        /// </summary>
		private int inputSize;
        /// <summary>
        /// A bias which is added to the sum of inputs multiplied by their weight, when calculating outputs.
        /// </summary>
		public float bias { get; set; }
        /// <summary>
        /// Last input, used for gradient descent
        /// </summary>
		private float[] lastInput;

        /// <summary>
        /// Reresents a neuron in the neural network. Weihts and bias are set to 0.
        /// </summary>
        /// <param name="size">The number of inputs the neuron has (input size)</param>
		public Neuron(int size)
		{
			inputSize = size;
			weights = new float[size];
			for (int i = 0; i < size; i++)
			{
				weights[i] = 0;
			}
			bias = 0;
		}

        public Neuron() { }

        /// <summary>
        /// Reresents a neuron in the neural network.
        /// </summary>
        /// <param name="weights">An array of floats reprenting the weights associated to each input. The input size is determined by the length of the array.</param>
        /// <param name="bias">A bias which is added to the sum of inputs multiplied by their weight, when calculating outputs.</param>
		public Neuron(float[] weights, float bias)
		{
			this.weights = weights;
			this.inputSize = weights.Length;
			this.bias = bias;
		}

		public float weight(int i) { return weights[i]; }

        // Sigmoid formula we learned in class
		private float sigmoid(float x)
		{
            // 1/1+e^(-x)
			return (float)(1.0 / (1.0 + Math.Pow(Math.E, -x)));
		}
        // Derivative of sigmoid formula
		private float sigmoidPrime(float x)
		{
			var y = sigmoid(x);
			return y * (1 - y);
		}
        //not sure what this is yet
		public float output(float[] input) 
		{
			var sum = bias;
			for (int i = 0; i < inputSize; i++)
			{
				sum += input[i] * weights[i];
			}
			lastInput = input;
			return sigmoid(sum);
		}

        /// <summary>
        /// Derivative of output function
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// sets the lastinput and returns the sigmoid derivative
		public float outputDerivative(float[] input)
		{ 
			var sum = bias;
			for (int i = 0; i < inputSize; i++) {
				sum += input[i] * weights[i];
			}
			lastInput = input;
			return sigmoidPrime(sum);
		}
        /// <summary>
        /// Adjusts weights and bias using gradient descent technique
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="nabla"></param>
        /// <param name="gamma"></param>
		public void gradientDescent(float delta, float nabla, float gamma) 
		{
			for (int i = 0; i < weights.Length; i++)
			{
				weights[i] = weights[i] + nabla * delta * outputDerivative(lastInput) * lastInput[i];
			}
			bias = bias + gamma * delta * outputDerivative(lastInput);
		}

		//    func gradientDescent(delta:Float){ //adjusts weights and bias using RPROP technique
		//        // to do
		//    }
	}
}

