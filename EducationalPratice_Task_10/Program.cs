using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_10
{
    class  Program
    {
       public static Random random =new Random();
        public static void Main(string[] args)
        {
            Graph graph = new Graph(10);
            graph.Generate();
            graph.Show();
        }
    }

    class Graph
    {
        private List<Point> _Graph;
        private Point Head;


        public Graph(int peaks)
        {

            _Graph = new List<Point>(peaks);
            Head = new Point(1);
        }

        public  void Generate()
        {
            for (int i = 0; i < _Graph.Capacity; i++)
            {
                Point node = new Point(Program.random.Next(_Graph.Capacity));
                _Graph[i] = node;
            }

        }
        public void Show()
        {
            foreach (Point node in _Graph)
                Console.WriteLine(node.ToString());
        }
        class Point
        {
            public int Data;
            public List<Point> Routes =new List<Point>();

            public Point(int Data) => this.Data = Data;

            public Point() => this.Data = Program.random.Next(10);

            public Point(int Data, params Point[] routes)
            {
                this.Data = Data;
                this.Routes.AddRange(routes);
            }
            /// <summary>
            /// Добавление пути
            /// </summary>
            /// <param name="routes"></param>
            public void AddRoute(params Point[] routes) => Routes.AddRange(routes);
            /// <summary>
            /// Удаление пути
            /// </summary>
            /// <param name="route"></param>
            public void RemoveRoute(Point route) => this.Routes.Remove(route);

            public override string ToString()
            {
                string routes = "";
                string info = this.Data.ToString();
                for (int i = 0; i < this.Routes.Count; i++)
                    routes += $"({Routes[i].Data.ToString()})-";
                return info + routes;

            
            }
            
        }
    }

}
