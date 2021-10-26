using System;
using System.Collections.Generic;
using System.Text;

namespace help
{
    static class Globals
    {
        public static readonly List<(string, string, int)> grafo = new List<(string, string, int)>
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
        public static readonly List<(string, int)> distanza_aria = new List<(string, int)>
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


        public static readonly string start = "A";
        public static readonly string goal = "Z";
    }
}
