using System;
using System.Collections.Generic;
using System.Threading;

namespace WinformsThreading_Common.Models
{
    public class DataGenerator
    {
        public delegate void PopulateData(ThreadDto data);
        public PopulateData populateData;

        private int _maxThreadCount { get; set; }
        private CancellationToken _token { get; set; }
        private Random _random { get; set; } = new Random((int)DateTime.Now.Ticks);
        private List<int> _threadsToReset = new List<int>();
        private List<Thread> _threads { get; set; }

        public static int MinDelay { get; set; }  = 500;
        public static int MaxDelay { get; set; }  = 2000;
        public static int MinLength { get; set; } = 5;
        public static int MaxLength { get; set; } = 10;

        public DataGenerator(int threadCount, CancellationToken token)
        {
            _token = token;
            _maxThreadCount = threadCount;
            _threads = new List<Thread>();
        }

        public void StartThreads()
        {
            PrepareThreads();

            while (true)
            {
                if (_token.IsCancellationRequested)
                    return;

                foreach (var index in _threadsToReset)
                {
                    if(!_threads[index].IsAlive)
                    {
                        _threads[index] = new Thread(ExecuteThreadTasks);
                        _threads[index].Start();
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void PrepareThreads()
        {
            for (; _threads.Count < _maxThreadCount;)
            {
                Thread thread = new Thread(ExecuteThreadTasks);
                _threads.Add(thread);
                thread.Start();
            }
        }

        private void ExecuteThreadTasks()
        {
            string generatedText = TextGenerator();
            int delay = GetRandom(MinDelay, MaxDelay);
            Thread.Sleep(delay);

            if (_token.IsCancellationRequested)
                return;

            int threadID = _threads.IndexOf(Thread.CurrentThread)+1;
            populateData?.Invoke(new ThreadDto(threadID, generatedText));

            _threadsToReset.Add(threadID - 1);
        }

        private string TextGenerator()
        {
            string text = "";
            int length = GetRandom(MinLength, MaxLength);

            for(int i = 0; i < length; i++)
            {
                int num = GetRandom(65, 90);
                text += (char)num;
            }
            return text;
        }

        private int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
