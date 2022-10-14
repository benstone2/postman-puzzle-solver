namespace PostmanChallenge2
{
    public class Graph
    {
        private Node _root;

        private List<Node> _nodes = new List<Node>();

        private List<Edge> _edges = new List<Edge>();

        public bool isValid => _edges.All(edge => edge.isValid);

        public Graph(int[] edgeWeights)
        {
            _root = new Node();
            _nodes.Add(_root);

            AddChain(_root, edgeWeights);
        }

        public void AddChain(Node from, int[] edgeWeights)
        {
            // This assumes the chain length is always > 1
            if (edgeWeights.Length == 1) 
            {
                var edge = new Edge(from, _root, edgeWeights[0]);

                _edges.Add(edge);
            }
            else
            {
                var toNode = new Node();

                _nodes.Add(toNode);

                var edge = new Edge(from, toNode, edgeWeights[0]);

                _edges.Add(edge);

                AddChain(toNode, edgeWeights.Skip(1).ToArray());
            }
        }

        public void Solve()
        {
            var startingNumber = 0;

            while (!isValid)
            {
                _root.Value = startingNumber;

                FillNextCircle(_root);

                PrintChain();

                startingNumber++;
            }
        }

        private void FillNextCircle(Node from)
        {
            var edge = _edges.Single(edge => edge.From == from);

            if (edge.To != _root)
            {
                edge.To.Value = edge.Weight - from.Value;

                FillNextCircle(edge.To);
            }
        }

        public void PrintChain() => PrintChain(_root);

        private void PrintChain(Node node)
        {
            Console.ForegroundColor = node == _root ? ConsoleColor.Cyan : ConsoleColor.White;

            Console.Write(node.Value);

            var edge = _edges.Single(edge => edge.From == node);

            edge.Print();

            if (edge.To == _root)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{_root.Value} \n");
            }
            else
            {
                PrintChain(edge.To);
            }
        }
    }
}
