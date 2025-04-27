using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using HashTable;

namespace DataStructures;

class Program
{
    static void Main(string[] args)
    {    
        const double sampleUniqueness = 0.75;

        int i;

        int[] sampleValues = new int[100000];

        Stopwatch stopwatch = new();
        Random random = new();
        Dictionary<string, string> dotnet = new();
        HashTable<string, string> oxford = new();
        HashSet.HashSet<int> set = new();

        stopwatch.Start();
        
        for (i = 0; i < 100000; i++)
        {
            oxford.Add(Convert.ToString(i), "Oxford: " + i);

        }
        
        stopwatch.Stop();
        Trace.WriteLine("Oxford contains " + oxford.Count + " entries.");
        Trace.WriteLine("Oxford insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks + " ticks."); // ~85K ticks.
        stopwatch.Reset();
        
        stopwatch.Start();
        Trace.WriteLine(oxford["99999"]); 
        stopwatch.Stop();
        Trace.WriteLine("Oxford retrieval completed in " + stopwatch.ElapsedTicks + " ticks."); // ~11K ticks.

        stopwatch.Start();

        for (i = 0; i < 100000; i++)
        {
            dotnet.Add(Convert.ToString(i), "Dotnet: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Dotnet contains " + dotnet.Count + " entries.");
        Trace.WriteLine("Dotnet insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks + " ticks."); // ~80K ticks.
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(dotnet["99999"]);
        stopwatch.Stop();
        Trace.WriteLine("Dotnet retrieval completed in " + stopwatch.ElapsedTicks + " ticks."); // ~8K ticks.

        for (i = 0; i < Math.Round(sampleValues.Length * sampleUniqueness) - 1; i++)
            sampleValues[i] = i;

        while (i < sampleValues.Length - 1)
        {
            sampleValues[i] = sampleValues[random.Next(0, i - 1)];

            i++;
            
        }

        for (i = 0; i < sampleValues.Length - 1; i++)
            set.Add(sampleValues[i]);

    }

}
