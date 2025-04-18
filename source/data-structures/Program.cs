using System.Diagnostics;
using HashTable;

namespace DataStructures;

class Program
{
    static void Main(string[] args)
    {    
        Stopwatch stopwatch = new();

        Dictionary<string, string> dotnet = new Dictionary<string, string>();
        HashTable<string, string> oxford = new HashTable<string, string>();

        stopwatch.Start();
        
        for (int i = 0; i < 100000; i++)
        {
            oxford.Add(Convert.ToString(i), "Oxford: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Oxford insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks + " ticks.");
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(oxford.Retrieve("756"));
        stopwatch.Stop();
        Trace.WriteLine("Oxford retrieval completed in " + stopwatch.ElapsedTicks + " ticks.");

        stopwatch.Start();

        for (int i = 0; i < 100000; i++)
        {
            dotnet.Add(Convert.ToString(i), "Dotnet: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Dotnet insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks + " ticks.");
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(dotnet["99999"]);
        stopwatch.Stop();
        Trace.WriteLine("Dotnet retrieval completed in " + stopwatch.ElapsedTicks + " ticks.");

    }


}
