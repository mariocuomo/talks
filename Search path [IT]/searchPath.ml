exception NotFound

(*dichiariamo il tipo 'a graph come una lista di coppie di tipo 'a*)
type 'a graph = ('a * 'a) list
let grafo = [("A","B");
            ("B","F");
            ("B","C");
            ("B","T");
            ("B","D");
            ("C","F");
            ("C","E");
            ("F","E");
            ("F","G");
            ("F","H");
            ("T","U");
            ("U","M");
            ("D","E");
            ("E","G");
            ("E","M");
            ("E","L");
            ("G","I");
            ("H","I");
            ("I","L");
            ("L","S");
            ("N","O");
            ("N","L");
            ("M","V");
            ("V","R");
            ("R","Q");
            ("O","Q");
            ("S","R");
            ("P","Q");
            ("M","N");
            ("O","P");
            ("P","Z")]

(*  vicini : 'a -> 'a graph -> 'a list  *)
(* vicini x g = ritorna la lista dei vicini del nodo x nel grafo g*)
let rec vicini nodo = function 
    [] -> []
  | (x,y)::rest ->
      if x = nodo then y::vicini nodo rest
      else if y = nodo then x::vicini nodo rest
      else vicini nodo rest

(* search_path : 'a graph -> 'a -> 'a' -> 'a list *)
(* search_path g start goal = ritorna un cammino nel grafo g dal nodo start al nodo goal *)

(* ricerca a partire da un singolo nodo *)
(* from_node: 'a list -> 'a -> 'a list 
from_node visited x = ritorna un cammino che non passa per nodi in visited,
                    da x fino al nodo goal*) 

(* ricerca a partire da una lista di nodi, tutti vicini di uno
stesso nodo *)
(* from_list: 'a list -> 'a list -> 'a list
from_list visited nodes = ritorna un cammino che non passa per nodi in visited,
             e che parte da un nodo in nodes fino al nodo goal *)
let search_path graph start goal =
  let rec from_node visited x =
    if List.mem x visited 
    then raise NotFound
    else if x=goal then [x]
         else x::from_list (x::visited) (vicini x graph)
  and from_list visited = function
      [] -> raise NotFound
    | x::rest ->	try from_node visited x 
        			with NotFound -> from_list visited rest
   in from_node [] start
