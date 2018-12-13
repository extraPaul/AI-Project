using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwok
{
    public class SignalUtility
    {
        public static float[] GenerateSignal(float[] frequencies, float[] amplitudes, float time, int sampleRate) {

            float temp;
            var signal = new List<float>();
            for(int j = 0; j < (int)((float)sampleRate * time); j++) { //iterate over one second
                temp = 0;
                for(int k = 0; k < frequencies.Length; k++) { // iterate over frequencies
                    temp += amplitudes[k] * (float)Math.Cos(frequencies[k] * 2 * Math.PI * j / sampleRate);
                }
                signal.Add(temp);
            }
            temp = 0;
            for(int k = 0; k < frequencies.Length; k++) { // this loop generates last point in signal
                temp += amplitudes[k] * (float)Math.Cos(frequencies[k] * 2 * Math.PI * time);
            }
            signal.Add(temp);

            return signal.ToArray();
        }

        public static float[] ScaleSignal(float[] signal, float scale) {
            var retArr = new float[signal.Length];
            for (int i = 0; i < signal.Length; i++) {
                retArr[i] = signal[i] * scale;
            }

            return retArr;
        }

        public static float[] DTFT(float[] input) {
            // returns array of amplitudes of cosines in signal, value k in fourier[k] is k cycles per sample

            //Also based on Phil's code

            var n = input.Length;
            var fourier = new float[n];
            float angle;
            float realsum;
            float imsum;
            for (var i = 0; i < n; i++) {
                realsum = 0;
                imsum = 0;
                for (var j = 0; j < n; j++) {
                    angle = (float)(-2 * Math.PI * i * j / n);
                    realsum += input[j] *(float) Math.Cos(angle);
                    imsum += input[i] * (float)Math.Sin(angle);
                }
                fourier[i] = (float)Math.Sqrt(imsum * imsum + realsum * realsum);
                
            }
            return fourier;

            /*Phil's Swift code
            var real = new float[input.Length];
            Array.Copy(input, real, input.Length);
            var imaginary = [Float](repeating: 0.0, count: input.count);
            var splitComplex = DSPSplitComplex(realp: &real, imagp: &imaginary);

            Complex num;
            Fft<doube> fourier;

        var length = vDSP_Length(floor(log2(Float(input.count))))
        var radix = FFTRadix(kFFTRadix2)
        let weights = vDSP_create_fftsetup(length, radix)
        vDSP_fft_zip(weights!, &splitComplex, 1, length, FFTDirection(FFT_FORWARD))


        var magnitudes = [Float](repeating: 0.0, count: input.count)
        vDSP_zvmags(&splitComplex, 1, &magnitudes, 1, vDSP_Length(input.count));


        var normalizedMagnitudes = [Float](repeating: 0.0, count: input.count);
        vDSP_vsmul(sqrtArr(magnitudes), 1, [2.0 / Float(input.count)], &normalizedMagnitudes, 1, vDSP_Length(input.count))


        vDSP_destroy_fftsetup(weights);
        
            return normalizedMagnitudes;

            return null;*/
        }

        static float[] sqrtArr(float[] arr) {
            var roots = new float[arr.Length];
            for(int i = 0; i < arr.Length; i++) {
                roots[i] = (float)Math.Sqrt(arr[i]);
            }
            return roots;
        }
    }
}
