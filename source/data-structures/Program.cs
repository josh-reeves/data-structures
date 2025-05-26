using System.Diagnostics;
using HashCollections;

namespace DataStructures;

class Program
{    
    static void Main(string[] args)
    {    
        const double sampleUniqueness = 0.75;

        int i,
            testValue = 5;

        StreamWriter logWriter;
        
        HashTableTests();
        HashSetTests();
        StackTests();
        QueueTests();

        void HashTableTests()
        {
            Stopwatch stopwatch = new();
            Dictionary<string, string> dotnet = new();
            HashTable<string, string> oxford = new();

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
            Trace.WriteLine(oxford[Convert.ToString(testValue)]); 
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
            Trace.WriteLine(dotnet[Convert.ToString(testValue)]);
            stopwatch.Stop();
            Trace.WriteLine("Dotnet retrieval completed in " + stopwatch.ElapsedTicks + " ticks."); // ~8K ticks.

            oxford.Add("5", "1000");
            oxford.OverWrite = true;
            oxford.Add("5", "3000");
            
            Trace.WriteLine(oxford.GetValue("5"));

            
        }

        void HashSetTests()
        {
            int[] sampleValues = new int[100000];

            HashCollections.HashSet<int> set = new();
            logWriter = new(Path.Combine(Directory.GetCurrentDirectory(), "set.csv"))
            {
                AutoFlush = true

            };

            for (i = 0; i <= sampleValues.Length * sampleUniqueness - 1; i++)
                sampleValues[i] = i;

            while (i < sampleValues.Length)
            {
                sampleValues[i] = sampleValues[sampleValues.Length - i]; /* The value of i will start at 74,999. This will start at 100,000 - i and tend 
                                                                        *     toward 0 as i grows, copying the existing value at 
                                                                        *     sampleValues[100,000 - i] back into the array a second time.*/

                i++;
                
            }

            // Reset i and attempt to add all values in sampleValues to set. 25,000 of these should be duplicate values.
            for (i = 0; i < sampleValues.Length; i++) 
                set.Add(sampleValues[i]);

            foreach (int num in set)
                logWriter.WriteLine(num); // Tracks all values in set to confirm that none are missing.

            // Tests for hash set removal and re-addition:
            set.Remove(testValue);

            try
            {
                Trace.WriteLine(set.Retrieve(testValue));

            }
            catch
            {
                Trace.WriteLine("The specified value was successfully removed and cannot be retrieved.");

            }

            set.Add(testValue);

            Trace.WriteLine(set.Retrieve(testValue));

        }

        void StackTests()
        {
            bool isPalindrome;
            string[] words = ["civic", "radar", "kayak", "rotor", "madam", "tattarrattat", "palindrome", "water", "mug", "fish", "monitor"];

            Stack.Stack<char> chars = new Stack.Stack<char>();

            foreach (string word in words)
            {
                isPalindrome = true;

                for (i = 0; i < word.Length / 2; i++)
                    chars.Push(word[i]);

                if (word.Length % 2 != 0)
                    i++;

                while (i < word.Length)
                {
                    if (chars.Pop() != word[i])
                    {
                        isPalindrome = false;

                        break;

                    }

                    i++;

                }

                Trace.WriteLine(word + " is" + (isPalindrome ? " ": " not ") + "a palindrome");
                
            }

        }

        void QueueTests()
        {
            Queue.Queue<char> queue = new Queue.Queue<char>();

            char[] text = "If I'm not back in five minutes, just wait longer.".ToArray();

            for (i = 0; i < text.Length; i++)
                queue.Enqueue(text[i]);

            while (queue.Peek() != 0)
            {
                Thread.Sleep(10);

                Trace.Write(queue.Dequeue());

            }

        }
        
    }



}
