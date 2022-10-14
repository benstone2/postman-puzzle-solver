using PostmanChallenge2;
using System.Diagnostics;


var testCaseDictionary = new Dictionary<string, int[]>();

testCaseDictionary.Add("Question 1", new int[] { 16, 10, 16, 24, 24 });
testCaseDictionary.Add("Question 2", new int[] { 32, 26, 17, 17, 30 });
testCaseDictionary.Add("Longer question", new int[] { 26, 23, 23, 13, 7, 20, 33, 16, 3, 21, 25, 14, 15, 18, 29 });
testCaseDictionary.Add("With negatives", new int[] { -8, -7, 25, 17, 21, 4, -28, -26, 6, 9, -3, 0, 5, 21 });

var timer = new Stopwatch();

foreach (var test in testCaseDictionary)
{
    timer.Start();
    Console.WriteLine(test.Key);

    var graph = new Graph(test.Value);

    graph.Solve();

    timer.Stop();
    Console.WriteLine($"Time taken: {timer.ElapsedMilliseconds} \n");
    timer.Reset();
}
