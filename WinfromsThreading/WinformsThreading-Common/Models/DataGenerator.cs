using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WinformsThreading_Common.Models
{
    public class DataGenerator
    {
        public delegate void PopulateData(ThreadDto data);

        private CancellationToken _token { get; set; }
        private int _threadCount { get; set; }

        private Queue<Thread> _threads { get; set; }

        public DataGenerator(int threadCount, CancellationToken token, ref PopulateData populateData)
        {
            _token = token;
            _threadCount = threadCount;
            _threads = new Queue<Thread>();
            Start();
        }

        public void Start()
        {

        }
    }
}
