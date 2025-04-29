using System.Diagnostics;
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
        StreamWriter logWriter = new (Path.Combine(Directory.GetCurrentDirectory(), "set.csv"));
        Dictionary<string, string> dotnet = new();
        HashTable<string, string> oxford = new();
        HashSet.HashSet<int> set = new();

        logWriter.AutoFlush = true;

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

        for (i = 0; i <= Math.Round(sampleValues.Length * sampleUniqueness) - 1; i++)
            sampleValues[i] = i;

        while (i < sampleValues.Length)
        {
            sampleValues[i] = sampleValues[sampleValues.Length - i]; /* The value of i will start at 74,999. This will start at 100,000 - i and tend 
                                                                      *     toward 0 as i grows, copying the existing value at 
                                                                      *     sampleValues[100,000 -i] back into the array a second time.*/

            i++;
            
        }

        // Reset i and attempt to add all values in sampleValues to set. 25,000 of these should be duplicate values.
        for (i = 0; i < sampleValues.Length; i++) 
            set.Add(sampleValues[i]);

        foreach (int num in set)
            logWriter.WriteLine(num);

    }

}
