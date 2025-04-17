using System.Diagnostics;
using Oxford;

namespace Dictionaries;

class Program
{
    static void Main(string[] args)
    {    
        Stopwatch stopwatch = new();

        Dictionary<int, string> dotnet = new Dictionary<int, string>();
        Oxford<int, string> oxford = new Oxford<int, string>(500);

        stopwatch.Start();
        
        for (int i = 0; i < 100000; i++)
        {
            oxford.Add(i, "Oxford: " + i);

        }

        stopwatch.Stop();
        Trace.WriteLine("Oxford insertion of 1,000,000 elements completed in " + stopwatch.ElapsedTicks);
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
        Trace.WriteLine("Dotnet insertion of 1,000,000 elements completed in " + stopwatch.ElapsedTicks);
        stopwatch.Reset();

        stopwatch.Start();
        Trace.WriteLine(dotnet[99999]);
        stopwatch.Stop();
        Trace.WriteLine("Oxford retrieval completed in " + stopwatch.ElapsedTicks);

    }


}
