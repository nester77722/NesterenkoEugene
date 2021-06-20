using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace MyProject
{
    class Program
    {
        static void Main()
        {
            CancellationTokenSource printFibonacciTokenSource = new CancellationTokenSource();
            CancellationToken printFibonacciCancellationToken = printFibonacciTokenSource.Token;

            PrintFibonacciAsync(printFibonacciCancellationToken);

            CancellationTokenSource getFibonacciTokenSource = new CancellationTokenSource();
            CancellationToken getFibonacciCancellationToken = getFibonacciTokenSource.Token;

            ulong current = 40;
            ulong max = 0;

            while (true)
            {
                var task = GetFibonacciAsync(current, getFibonacciCancellationToken);
                
                Thread.Sleep(10000);

                if (task.IsCompleted)
                {
                    max = task.Result;
                    current++;
                }
                else
                {
                    getFibonacciTokenSource.Cancel();
                    break;
                }
            }

            Console.WriteLine($"Max value {max}");
        }

        static async void PrintFibonacciAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            List<Task<ulong>> tasks = new List<Task<ulong>>();
            tasks.Add(GetFibonacciAsync(20, token));
            tasks.Add(GetFibonacciAsync(13, token));
            tasks.Add(GetFibonacciAsync(17, token));

            await Task.WhenAll(tasks);

            foreach (var t in tasks)
            {
                Console.WriteLine(t.Result);
            }
        }

        static async Task<ulong> GetFibonacciAsync(ulong n, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return default;
            }

            return await Task<ulong>.Run(() => Fibonacci(n, token));
        }

        static ulong Fibonacci(ulong n, CancellationToken token)
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
