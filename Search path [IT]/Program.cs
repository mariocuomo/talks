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
        public Nodo(string nome, Nodo genitore)
        {
            this.nome = nome;
            this.genitore = genitore;
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
            BFS_tree();
            Console.WriteLine("=================");
            DFS_graph();
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
                /*
                i++;
                */
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
    }
}
