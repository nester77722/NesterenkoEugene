using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource source1 = new CancellationTokenSource();
            PrintThreeFiboAsync(source1.Token);

            CancellationTokenSource source2 = new CancellationTokenSource();

            ulong n = 10;
            ulong max = 0;
            while (true)
            {
                Task<ulong> fibonacciAsync = FibonacciAsync(n, source2.Token);
                Thread.Sleep(10000);
                if (!fibonacciAsync.IsCompleted)
                {
                    source2.Cancel();
                    break;
                }
                max = fibonacciAsync.Result;
                n++;
            }

            Console.WriteLine($"Max value {max}");
        }

        private static async void PrintThreeFiboAsync(CancellationToken token)
        {
            List<Task<ulong>> tasks = new List<Task<ulong>>();

            tasks.Add(Task<ulong>.Run(() => Fibonacci(27, token)));
            tasks.Add(Task<ulong>.Run(() => Fibonacci(23, token)));
            tasks.Add(Task<ulong>.Run(() => Fibonacci(24, token)));

            await Task.WhenAll(tasks);

            foreach (var t in tasks)
            {
                Console.WriteLine(t.Result);
            }
        }

        private static async Task<ulong> FibonacciAsync(ulong n, CancellationToken token)
        {
            return await Task<ulong>.Run(() => Fibonacci(n, token));
        }

        private static ulong Fibonacci(ulong n, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return default;
            }

            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1, token) + Fibonacci(n - 2, token);
            }

        }
    }
}
