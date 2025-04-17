using System.Diagnostics;
using HashTable;

namespace DataStructures;

class Program
{
    static void Main(string[] args)
    {    
        Stopwatch stopwatch = new();

        Dictionary<int, string> dotnet = new Dictionary<int, string>();
        HashTable<int, string> oxford = new HashTable<int, string>();

        stopwatch.Start();
        
        for (int i = 0; i < 100000; i++)
        {
            oxford.Add(i, "Oxford: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Oxford insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks);
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(oxford.Retrieve(99999));
        stopwatch.Stop();
        Trace.WriteLine("Oxford retrieval completed in " + stopwatch.ElapsedTicks);

        stopwatch.Start();

        for (int i = 0; i < 100000; i++)
        {
            dotnet.Add(i, "Dotnet: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Dotnet insertion of 100,000 elements completed in " + stopwatch.ElapsedTicks);
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(dotnet[99999]);
        stopwatch.Stop();
        Trace.WriteLine("Oxford retrieval completed in " + stopwatch.ElapsedTicks);

    }


}
