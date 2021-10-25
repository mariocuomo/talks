using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace help
{
    class Nodo
    {
        public string nome { get; set; }
        public Nodo genitore { get; set; }
        public int costo_parziale { get; set; }

        public Nodo(string nome, Nodo genitore)
        {
            this.nome = nome;
            this.genitore = genitore;
        }

        public Nodo(string nome, Nodo genitore, int costo_parziale)
        {
            this.nome = nome;
            this.genitore = genitore;
            this.costo_parziale = costo_parziale;
        }

    }

    class ComparatoreGreedy : IComparer<Nodo>
    {
        private static readonly List<(string, int)> distanza_aria = new List<(string, int)>
            {
                ("A",20),
                ("B",18),
                ("C",15),
                ("D",10),
                ("E",5),
                ("F",1),
                ("G",18),
                ("H",5),
                ("I",8),
                ("L",7),
                ("M",13),
                ("N",22),
                ("O",19),
                ("P",4),
                ("Q",2),
                ("R",10),
                ("S",11),
                ("T",3),
                ("U",2),
                ("V",1),
                ("Z",0),
            };

        public int Compare(Nodo x, Nodo y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            // "CompareTo()" method
            return (distanza_aria.Find(item => item.Item1 == x.nome).Item2)+x.costo_parziale.CompareTo((distanza_aria.Find(item => item.Item1 == y.nome).Item2)+ y.costo_parziale);
        }
    }

    class ComparatoreA : IComparer<Nodo>
    {
        private static readonly List<(string, int)> distanza_aria = new List<(string, int)>
            {
                ("A",20),
                ("B",18),
                ("C",15),
                ("D",10),
                ("E",5),
                ("F",1),
                ("G",18),
                ("H",5),
                ("I",8),
                ("L",7),
                ("M",13),
                ("N",22),
                ("O",19),
                ("P",4),
                ("Q",2),
                ("R",10),
                ("S",11),
                ("T",3),
                ("U",2),
                ("V",1),
                ("Z",0),
            };

        public int Compare(Nodo x, Nodo y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            // "CompareTo()" method
            return (distanza_aria.Find(item => item.Item1 == x.nome).Item2).CompareTo((distanza_aria.Find(item => item.Item1 == y.nome).Item2));
        }
    }

    class Program
    {
        private static readonly List<(string, string, int)> grafo = new List<(string, string, int)>
            {
                ("A","B",5),
                ("B","F",8),
                ("B","C",4),
                ("B","T",3),
                ("B","D",2),
                ("C","F",1),
                ("C","E",1),
                ("F","E",3),
                ("F","G",2),
                ("F","H",5),
                ("T","U",4),
                ("U","M",2),
                ("D","E",3),
                ("E","G",7),
                ("E","M",1),
                ("E","L",1),
                ("G","I",2),
                ("H","I",9),
                ("I","L",1),
                ("L","S",1),
                ("N","O",7),
                ("N","L",6),
                ("M","V",3),
                ("V","R",5),
                ("R","Q",3),
                ("O","Q",10),
                ("S","R",2),
                ("P","Q",4),
                ("M","N",2),
                ("O","P",2),
                ("P","Z",1),
            };

        static readonly string start = "A";
        static readonly string goal = "Z";
        static void Main(string[] args)
        {
            Console.WriteLine("=================\n   BFS_tree\n=================");
            BFS_tree();
            Console.WriteLine("\n=================\n   DFS_graph\n=================");
            DFS_graph();
            Console.WriteLine("\n=================\n   GreedySearch\n=================");
            GreedySearch();
            Console.WriteLine("\n=================\n   AStarSearch\n=================");
            AStarSearch();
            Console.WriteLine("\n=================\n   DijkstraSearch\n=================");
            DijkstraSearch();
        }

        public static void DFS_tree()
        {
            /*
            int i = 0;
            */
            Stack<Nodo> pila = new Stack<Nodo>();
            pila.Push(new Nodo(start, null));

            while (pila.Count != 0)
            {
                /*
                if (i < 20)
                    StampaContenuto(pila);
                */
                Nodo nodo = pila.Pop();
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    Nodo nodoFiglio = new Nodo(nodoVicino, nodo);
                    pila.Push(nodoFiglio);
                }
                /*
                i++;
                */
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a " + goal);

        }

        public static void BFS_tree()
        {
            /*
            int i = 0;
            */
            Queue<Nodo> coda = new Queue<Nodo>();
            coda.Enqueue(new Nodo(start, null));

            while (coda.Count != 0)
            {
                /*
                if(i<20)
                    StampaContenuto(coda);
                */

                Nodo nodo = coda.Dequeue();
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    Nodo nodoFiglio = new Nodo(nodoVicino, nodo);
                    coda.Enqueue(nodoFiglio);
                }
                
                //i++;
                
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a "+goal);
        }

        public static void DFS_graph()
        {
            /*
            int i = 0;
            */
            List<string> citta_visitate = new List<string>();
            citta_visitate.Add(start);
            Stack<Nodo> pila = new Stack<Nodo>();
            pila.Push(new Nodo(start, null));

            while (pila.Count != 0)
            {
                /*
                if (i < 20)
                    StampaContenuto(pila);
                */

                Nodo nodo = pila.Pop();
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    if (!citta_visitate.Contains(nodoVicino))
                    {
                        Nodo nodoFiglio = new Nodo(nodoVicino, nodo);
                        pila.Push(nodoFiglio);
                        citta_visitate.Add(nodoVicino);
                    }
                }
                /*
                i++;
                */
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a " + goal);

        }

        public static void BFS_graph()
        {
            /*
            int i = 0;
            */

            List<string> citta_visitate = new List<string>();
            citta_visitate.Add(start);
            Queue<Nodo> coda = new Queue<Nodo>();
            coda.Enqueue(new Nodo(start, null));

            while (coda.Count != 0)
            {
                /*
                if (i < 20)
                    StampaContenuto(coda);
                */
                Nodo nodo = coda.Dequeue();
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    if (!citta_visitate.Contains(nodoVicino)) {
                        Nodo nodoFiglio = new Nodo(nodoVicino, nodo);
                        coda.Enqueue(nodoFiglio);
                        citta_visitate.Add(nodoVicino);
                    }
                }
                /*
                i++;
                */
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a " + goal);
        }

        public static void GreedySearch()
        {
            /*
            int i = 0;
            */
            List<string> citta_visitate = new List<string>();
            citta_visitate.Add(start);
            List<Nodo> lista_nodi = new List<Nodo>();
            lista_nodi.Add(new Nodo(start, null));

            while (lista_nodi.Count != 0)
            {
                /*
                if (i < 20)
                    StampaContenuto(pila);
                */

                Nodo nodo = lista_nodi.First();
                lista_nodi.RemoveAt(0);
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    if (!citta_visitate.Contains(nodoVicino))
                    {
                        Nodo nodoFiglio = new Nodo(nodoVicino, nodo);
                        lista_nodi.Add(nodoFiglio);
                        lista_nodi.Sort(0, lista_nodi.Count, new ComparatoreGreedy());
                        citta_visitate.Add(nodoVicino);
                    }
                }
                /*
                i++;
                */
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a " + goal);

        }

        public static void AStarSearch()
        {
            /*
            int i = 0;
            */
            List<string> citta_visitate = new List<string>();
            citta_visitate.Add(start);
            List<Nodo> lista_nodi = new List<Nodo>();
            lista_nodi.Add(new Nodo(start, null));

            while (lista_nodi.Count != 0)
            {
                /*
                if (i < 20)
                    StampaContenuto(pila);
                */

                Nodo nodo = lista_nodi.First();
                lista_nodi.RemoveAt(0);
                if (nodo.nome == goal)
                {
                    List<string> percorso = RicostruisciPercorso(nodo);
                    StampaPercorso(percorso);
                    return;
                }

                foreach (string nodoVicino in Vicini(nodo.nome))
                {
                    if (!citta_visitate.Contains(nodoVicino))
                    {
                        int costo_arco = grafo.Where(x => (x.Item1 == nodoVicino && x.Item2 == nodo.nome) || ((x.Item1 == nodo.nome && x.Item2 == nodoVicino))).First().Item3;

                        Nodo nodoFiglio = new Nodo(nodoVicino, nodo,nodo.costo_parziale+costo_arco);
                        lista_nodi.Add(nodoFiglio);
                        lista_nodi.Sort(0, lista_nodi.Count, new ComparatoreA());
                        citta_visitate.Add(nodoVicino);
                    }
                }
                /*
                i++;
                */
            }
            Console.WriteLine("Non è stato possibile trovare un cammino che porta da " + start + " a " + goal);

        }

        public static void DijkstraSearch()
        {
            Dictionary<string, int> distanza_partenza_nodo = new Dictionary<string, int>();
            Dictionary<string, string> nodo_precedente = new Dictionary<string, string>();
            List<string> path = new List<string>();

            foreach (String nodo in Nodi())
            {
                distanza_partenza_nodo.Add(nodo, int.MaxValue);
                nodo_precedente.Add(nodo, null);
            }

            distanza_partenza_nodo[start]= 0;

            List<String> nodi = Nodi();
            while (nodi.Count != 0)
            {
                String nodo = null;
                int min_distanza = int.MaxValue;

                foreach (String _nodo in nodi)
                {
                    int distanza = distanza_partenza_nodo.GetValueOrDefault(_nodo);
                    if (distanza < min_distanza)
                    {
                        min_distanza = distanza;
                        nodo = _nodo;
                    }
                }

                nodi.Remove(nodo);

                List<string> vicini = Vicini(nodo);
                List<string> vicini_filtrati = Enumerable.ToList(vicini.Where(x => nodi.Contains(x)));

                foreach (string vicino in vicini_filtrati)
                {
                    int alt = distanza_partenza_nodo.GetValueOrDefault(nodo) + grafo.Where(x => (x.Item1 == nodo && x.Item2 == vicino) || ((x.Item1 == vicino && x.Item2 == nodo))).First().Item3;
                    if(alt< distanza_partenza_nodo.GetValueOrDefault(vicino))
                    {
                        distanza_partenza_nodo[vicino]= alt;
                        nodo_precedente[vicino]= nodo;
                    }
                }
            }

            
            string tmp = goal;
            while (true)
            {
                path.Add(tmp);
                tmp = nodo_precedente.GetValueOrDefault(tmp);

                if (tmp == start)
                {
                    path.Add(start);
                    path.Reverse();
                    StampaPercorso(path);
                    break;
                }
            }


        }

        public static void StampaContenuto(IEnumerable<Nodo> contenitore)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Nodo nodo in contenitore)
            {
                sb.Append(nodo.nome + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        public static void StampaPercorso(List<string> percorso)
        {
            int costo = CalcolaCosto(percorso);
            StringBuilder sb = new StringBuilder();
            sb.Append("La soluzione trovata è la seguente:\n");
            foreach (string stringa in percorso)
            {
                sb.Append(stringa + " ");
            }
            sb.Append("La soluzione trovata ha costo "+costo);
            Console.WriteLine(sb.ToString());
        }

        public static int CalcolaCosto(List<string> percorso)
        {
            int costo = 0;
            for (int i = 0; i < percorso.Count-1; i++)
            {
                var query = grafo.Where(x => (x.Item1 == percorso[i] && x.Item2 == percorso[i+1]) || ((x.Item1 == percorso[i+1] && x.Item2 == percorso[i])));

                foreach ((string,string,int) arco in query)
                {
                    costo = costo + arco.Item3;
                }

            }
            return costo;
        }
        public static List<string> RicostruisciPercorso(Nodo nodo)
        {
            List<string> percorso = new List<string>();
            Nodo tmp = nodo;
            while (tmp != null)
            {
                percorso.Add(tmp.nome);
                tmp = tmp.genitore;
            }

            percorso.Reverse();
            return percorso;
        }
        public static List<string> Vicini(string nome)
        {            
            List<string> result = new List<string>();

            foreach ((string, string, int) item in grafo)
            {
                if (item.Item1.Equals(nome))
                    result.Add(item.Item2);
                if (item.Item2.Equals(nome))
                    result.Add(item.Item1);
            }           
            return result;
        }

        public static List<String> Nodi()
        {
            HashSet<String> nodi = new HashSet<string>();
            foreach ((string,string,int) arco in grafo)
            {
                nodi.Add(arco.Item1);
                nodi.Add(arco.Item2);
            }
            return nodi.ToList();
        }
    }
}
