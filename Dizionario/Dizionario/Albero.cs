using System;
using System.Collections.Generic;
using System.Linq;

namespace Dizionario
{
    public class Albero
    {
        private Nodo _root;
        
        public Nodo Root
        {
            get { return _root; }
            set { _root = value; }
        }

        public Albero()
        {
            Root = new Nodo("", false, 0);
            Root.Successivi.Add(new Nodo("a",false, 1));
            Root.Successivi.Add(new Nodo("b",false, 1));
            Root.Successivi.Add(new Nodo("c",false, 1));
            Root.Successivi.Add(new Nodo("d",false, 1));
            Root.Successivi.Add(new Nodo("e",false, 1));
            Root.Successivi.Add(new Nodo("f",false, 1));
            Root.Successivi.Add(new Nodo("g",false, 1));
            Root.Successivi.Add(new Nodo("h",false, 1));
            Root.Successivi.Add(new Nodo("g",false, 1));
            Root.Successivi.Add(new Nodo("h",false, 1));
            Root.Successivi.Add(new Nodo("i",false, 1));
            Root.Successivi.Add(new Nodo("j",false, 1));
            Root.Successivi.Add(new Nodo("k",false, 1));
            Root.Successivi.Add(new Nodo("l",false, 1));
            Root.Successivi.Add(new Nodo("m",false, 1));
            Root.Successivi.Add(new Nodo("n",false, 1));
            Root.Successivi.Add(new Nodo("o",false, 1));
            Root.Successivi.Add(new Nodo("p",false, 1));
            Root.Successivi.Add(new Nodo("q",false, 1));
            Root.Successivi.Add(new Nodo("r",false, 1));
            Root.Successivi.Add(new Nodo("s",false, 1));
            Root.Successivi.Add(new Nodo("t",false, 1));
            Root.Successivi.Add(new Nodo("u",false, 1));
            Root.Successivi.Add(new Nodo("v",false, 1));
            Root.Successivi.Add(new Nodo("w",false, 1));
            Root.Successivi.Add(new Nodo("x",false, 1));
            Root.Successivi.Add(new Nodo("y",false, 1));
            Root.Successivi.Add(new Nodo("z",false, 1));
        }

        public void CreaAlbero(Nodo[] nodi)
        {
            foreach (Nodo n in nodi)
            {
                AggiungineUno(n);
            }
        }

        public void AggiungineUno(Nodo n)
        {
            bool inserito = false;
            List<Nodo> livello = Root.Successivi;
            while (!inserito)
            {
                int dove = Contiene(livello, n.Sezione);
                if(dove == -1)
                {
                    int sezioneDove = Contiene(livello, n.Sezione.Substring(IdentificaLivello(livello)));
                    if (livello[0].Livello >= n.Sezione.Length)
                    {
                        inserito = true;
                        livello.Add(n);
                        n.Livello = livello[0].Livello;
                    }
                    else if (sezioneDove != -1)
                    {
                        livello = livello[sezioneDove].Successivi;
                    }
                    else
                    {
                        Nodo appoAggiungi = new Nodo(n.Sezione.Substring(IdentificaLivello(livello)), false, IdentificaLivello(livello));
                        livello.Add(appoAggiungi);
                        livello = livello.Last().Successivi;
                    }
                }
                else
                {
                    livello[dove].Definizioni.AddRange(n.Definizioni);
                    livello[dove].Parola = true;
                    inserito = true;
                }
            }
        }

        public static int Contiene(List<Nodo> nodi, String n)
        {
            int livello = nodi[0].Livello;
            string daControllare = n;
            for (int i = 0; i < nodi.Count; i++)
                if(nodi[i].Sezione == daControllare)
                    return i;
            return -1;
        }

        public static int IdentificaLivello(List<Nodo> ln)
        {
            int attuale = ln[0].Livello;
            switch (attuale)
            {
                case 1:
                    return 3;
                case 3:
                    return 5;
                case 5: 
                    return 7;
                default:
                    return Int32.MaxValue;
            }
        }
        
        public Nodo Cerca(string s)
        {
            Nodo n = new Nodo(s, false , 0);
            List<Nodo> livello = Root.Successivi;
            while (true)
            {
                int dove = Contiene(livello, n.Sezione);
                if(dove == -1)
                {
                    int sezioneDove = Contiene(livello, n.Sezione.Substring(IdentificaLivello(livello)));
                    if (sezioneDove != -1)
                    {
                        livello = livello[sezioneDove].Successivi;
                    }
                    else
                    {
                        return new Nodo("", false, 0);
                    }
                }
                else
                {
                    return livello[dove];
                }
            }
        }

        public static List<Nodo> TuttiFuori(Albero alberello)
        {
            List<Nodo> nodi = new List<Nodo>();
            Stack<Nodo> stack = new Stack<Nodo>();
            stack.Push(alberello.Root);
            while (stack.Count > 0)
            {
                Nodo n = stack.Pop();
                if (n.Parola)
                    nodi.Add(n);
                foreach (Nodo nodo in n.Successivi)
                    stack.Push(nodo);
            }

            Console.WriteLine("ciao");
            return nodi;
        }
    }
}