using System.Collections.Generic;

namespace ProcessPerformanceWatcher {

    public class MovingAverage {
        private Queue<double> _samples = new Queue<double>();
        private int           _windowSize;
        private double        _sampleAccumulator;
        public double         Average { get; private set; }

        public MovingAverage(int window_size = 32) {
            _windowSize = window_size;
        }

        /// <summary>
        /// Computes a new windowed average each time a new sample arrives
        /// </summary>
        /// <param name="newSample"></param>
        public void add_sample(double newSample) {
            _sampleAccumulator += newSample;
            _samples.Enqueue(newSample);
            if (_samples.Count > _windowSize) {
                _sampleAccumulator -= _samples.Dequeue();
            }
            Average = _sampleAccumulator / _samples.Count;
        }
    }
}
