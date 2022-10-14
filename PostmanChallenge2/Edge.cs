namespace PostmanChallenge2
{
    public class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }

        public int Weight { get; set; }

        public Edge(Node from, Node to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public bool isValid => From != null && To != null && From.Value + To.Value == Weight;

        public void Print()
        {
            Console.ForegroundColor = isValid ? ConsoleColor.Green : ConsoleColor.Red;

            Console.Write($" - {Weight} - ");
        }
    }
}
