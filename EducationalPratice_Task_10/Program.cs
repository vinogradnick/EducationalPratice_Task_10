using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_10
{
    class  Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph(10);
            graph.Generate();
            graph.Show();
            Console.ReadKey();
        }
    }

    class Graph
    {
        private List<Point> _Graph;
        private Point Head;

        static Random _rd = new Random();
        public Graph(int peaks)
        {
            _Graph = new List<Point>(peaks);
            Head = new Point(1);
        }

        public  void Generate()
        {
            for (int i = 0; i < _Graph.Capacity; i++)
            {
                Point node = new Point(_rd.Next(_Graph.Capacity));
                _Graph.Add(node);
            }

            for (int i = 0; i < _Graph.Count; i++)
            {
                Point[] points = new Point[_rd.Next(2,_Graph.Count)];
                for (int j = 0; j < points.Length; j++)
                    points[j] = _Graph[_rd.Next(_Graph.Count)];
                _Graph[i].AddRoute(points);
            }

        }
        public void Show()
        {
            foreach (Point node in _Graph)
                Console.WriteLine(node.ToString());
        }
        class Point
        {
            public int Data { get; set; }
            public List<Point> Routes =new List<Point>();

            public Point(int Data) => this.Data = Data;

            public Point() => this.Data = _rd.Next(10);

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
                string info = $"Вершина :{this.Data.ToString()} Ребра";
                for (int i = 0; i < this.Routes.Count; i++)
                    routes += $"({Routes[i].Data.ToString()})-";
                return info + routes;

            
            }
            
        }
    }

}
