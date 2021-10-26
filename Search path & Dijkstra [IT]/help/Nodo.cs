using System;
using System.Collections.Generic;
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

}
