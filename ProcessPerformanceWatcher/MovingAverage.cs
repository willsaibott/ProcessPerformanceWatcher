using System.Collections.Generic;

namespace ProcessPerformanceWatcher {

    public class MovingAverage {
        private Queue<double> samples = new Queue<double>();
        private int windowSize;
        private double sampleAccumulator;
        public double Average { get; private set; }

        public MovingAverage(int window_size = 32) {
            windowSize = window_size;
        }

        /// <summary>
        /// Computes a new windowed average each time a new sample arrives
        /// </summary>
        /// <param name="newSample"></param>
        public void add_sample(double newSample) {
            sampleAccumulator += newSample;
            samples.Enqueue(newSample);
            if (samples.Count > windowSize) {
                sampleAccumulator -= samples.Dequeue();
            }
            Average = sampleAccumulator / samples.Count;
        }
    }
}
