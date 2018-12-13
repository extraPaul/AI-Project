using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwok
{
    public class PermutationGenerator
    {
        int inputs;
        int outputs;
        int generations;
        int permutations;
        int tests;
        float[] frequencies;
            
        public PermutationGenerator(int input, int output, int gen, int permute, int test, float[] freq) {
            inputs = input; //size of fourier transform
            outputs = output; //size of note output
            generations = gen;
            permutations = permute;
            tests = test;
            frequencies = freq;
        }

        public string[] iterate(float nabla_max, float nabla_min, float gamma_max, float gamma_min) { // generates 36 groups of permutation members each

            /* Control neural net :
            nabla = nabla_min
            gamma = gamma_min
            nodes = [inputs, 2*inputs, 2*outputs, outputs]
            */

            var neuralNets = new List<Network>();
            var nabla_step = (nabla_max - nabla_min) / (float)permutations;
            var nabla = nabla_min;
            var gamma_step = (gamma_max - gamma_min) / (float)permutations;
            var gamma = nabla_min;

            //species 0 : 2 hidden layers
            var structure = new int[] { inputs, inputs, outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 0 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 1 : nabla variation
                neuralNets.Add(new Network(structure, nabla, gamma_min));
                nabla += nabla_step;
            }
            for (var i = 0; i < permutations; i++) { // family 2 : gamma variation

                neuralNets.Add(new Network(structure, nabla_min, gamma));
                gamma += gamma_step;

            }
            //species 1 : 2 hidden layers, large first hidden layer
            structure = new int[] { inputs, 2 * inputs, outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 3 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 4 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 5 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 2 : 2 hidden layers, large second hidden layer
            structure = new int[] { inputs, inputs, 2 * outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 6 : control
                neuralNets.Add(new Network(structure, nabla_min, gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 7 : nabla variation
                neuralNets.Add(new Network(structure, nabla, gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 8 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 3 : 2 hidden layers, large hidden layers
            structure = new int[] { inputs, 2 * inputs, 2 * outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 9 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 10 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 11 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 4 : 3 hidden layers
            structure = new int[] { inputs, inputs, (int)((inputs + outputs) / 2), outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 12 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 13 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 14 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 5 : 3 hidden layers, large first hidden layer
            structure = new int[] { inputs, 2 * inputs, (int)((inputs + outputs) / 2), outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 15 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 16 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 17 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 6 : 3 hidden layers, large second hidden layer
            structure = new int[] { inputs, inputs, inputs + outputs, outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 18 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 19 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 20 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 7 : 3 hidden layers, large last hidden layers
            structure = new int[] { inputs, inputs, (int)((inputs + outputs) / 2), 2 * outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 21 : control
                neuralNets.Add(new Network(structure, nabla_min, gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 22 : nabla variation
                neuralNets.Add(new Network(structure, nabla, gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 23 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 8 : 3 hidden layers, large first and second hidden layers
            structure = new int[] { inputs, 2 * inputs, inputs + outputs, outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 24 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 25 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 26 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 9 : 3 hidden layers, large first and third hidden layers
            structure = new int[] { inputs, 2 * inputs, (int)((inputs + outputs) / 2), 2 * outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 27 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 28 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;

            }
            for (var i = 0; i < permutations; i++) { // family 29 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;

            }
            //species 10 : 3 hidden layers, large second and third hidden layers
            structure = new int[]{inputs, inputs, inputs + outputs, 2 * outputs, outputs};
            for (var i = 0; i < permutations; i++) { // family 30 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 31 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;
                    
            }
            for (var i = 0; i < permutations; i++) { // family 32 : gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;
                    
            }
            //species 11 : 3 hidden layers, large hidden layers
            structure = new int[] { inputs, 2 * inputs, inputs + outputs, 2 * outputs, outputs };
            for (var i = 0; i < permutations; i++) { // family 33 : control
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma_min));
            }
            for (var i = 0; i < permutations; i++) { // family 34 : nabla variation
                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla, biasAdapt: gamma_min));
                nabla += nabla_step;
                    
            }
            for (var i = 0; i < permutations; i++) { // family 35: gamma variation

                neuralNets.Add(new Network(nodes: structure, weightAdapt: nabla_min, biasAdapt: gamma));
                gamma += gamma_step;
                    
            }

            return printData(neuralNets);
                
        }

            
        private string[] printData(List<Network> netData){
            List<string> text = new List<string>();
            AmpExpected temp;
            float cost;
            float[] error;
            for (var i = 0; i < netData.Count; i++) {
                if(i%permutations == 0){
                    text.Add("=== Family: " +  (i/permutations) + " ===");
                }
                if(i%(3*permutations) == 0){
                    text.Add("=== Species: " + (i/(3*permutations)) + " ===");
                }
                text.Add("=== permutation: " + (i%permutations) +" ===");
                for (var gen = 0; gen < generations; gen++) {
                    cost = 0.0f;
                    for (var j = 0; j < this.tests; j++) {
                        temp = createTest();
                        netData[i].learn(SignalUtility.DTFT(SignalUtility.GenerateSignal(frequencies, amplitudes: temp.amps, time: 1, sampleRate: inputs)), expected: temp.expected);
                    }
                    for (var j = 0; j < this.tests; j++) {
                        temp = createTest();
                        error = netData[i].calcError(SignalUtility.DTFT(SignalUtility.GenerateSignal(frequencies, amplitudes: temp.amps, time: 1, sampleRate: inputs - 1)), expected: temp.expected);
                        for (var k = 0; k < error.Length; k++) {
                            cost += Math.Abs(error[k]) / (float)(error.Length);
                        }
                    }
                    cost = cost / (float)this.tests;
                    //print("\(1.0-cost)", terminator: ";"); //prints
                    text.Add((1.0-cost).ToString());
                }
                text.Add("");
            }
            return text.ToArray();
        }

        protected struct AmpExpected {
            public float[] amps;
            public float[] expected;
            public AmpExpected(IEnumerable<float> amps, IEnumerable<float> expected)
            {
                this.amps = amps.ToArray();
                this.expected = expected.ToArray();
            }
        }

        AmpExpected createTest() {
            var amps = new List<float>();
            var expected = new List<float>();
            var rand = new Random();
            for (var i = 0; i < outputs; i++) {
                if(rand.NextDouble() > 0.5){
                    amps.Add(5.0f);
                    expected.Add(1f);
                }else{
                    amps.Add(0.1f);
                    expected.Add(0f);
                }
            }
            return new AmpExpected(amps, expected);
        }
    }
}
