using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Dizionario
{
    public partial class Form1 : Form
    {
        //struttura base: lista
        //il root contiene degli oggetti chiamati nodi, essi hanno una variabile booleana che determina se sono parole o soli nodi
        //di smistamento, nel caso fossero parole si andrà a vedere la lista contenente le definizioni di quella parola
        //Quando aggiungo una parola controllo con che lettera inizia, andò quindi in quel nodo e via così fino a quando vedo che la
        //lunghezza è minore del nodo successivo, se non trovo nessun nodo successivo che soddisfa le mie necessità, e la parola
        //è comunque più lunga della lunghezza dei successivi nodi creo un nuovo nodo, con quello che mi serve.
        //Quano apro il programma vado a legger il file di testo formattato in parola,def1,def2,defNUM e aggiungo ogni parola nell'albero
        //Visualizzazione: Una textbox all'interno della quale l'utente inserirà la sua parola, controllo se esiste, in tal caso mostro le
        //definizioni con avanti-> e <-indietro; nel caso invece non esistesse la aggiungo e mostro un'unica definizione vuota che
        //l'utente dovrà riempire, il nodo non verrà abilitato a parola
        //Quando chiudo il file scorro tutto il mio albero, rimuovendo i nodi man mano, per salvare le parole nei vari file
        
        Albero giovanni = new Albero();
        private bool italiano = true;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void caricaParole() //vado a caricare le parole dal file di testo 
        {
            //nome programma: gugol transleight
            
            //creare una finestra degli errori dove vengono visualizzati eventuali errori nel caricamento del file
            
            //quando cerco una parola devo guardare se il dodo restituito ha la sezione vuota o piena, se vuota vuol dire che non esiste
            
            List<Nodo> nodi = new List<Nodo>();
            if (File.Exists("dizionario.txt"))
            {
                using (StreamReader sr = new StreamReader("dizionario.txt"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    string[] stringa = sr.ReadLine().Split(';');
                                    nodi.Add(new Nodo(stringa[0], true, 0));
                                    for (int i = 1; i < stringa.Length; i++)
                                        nodi[nodi.Count - 1].AggiungiDefinizione(stringa[i]);
                                }
                            }
            }
            else
            {
                //converti un file binario di stringhe in un file di testo
            }
            giovanni.CreaAlbero(nodi.ToArray());
        }

        public void traduciAlbero()
        {
            List<Nodo> paroleItaliane = Albero.TuttiFuori(giovanni);
            List<Nodo> paroleInglese = new List<Nodo>();
            foreach (Nodo ita in paroleItaliane)
            {
                bool inserita = false;
                foreach (Nodo eng in paroleInglese)
                {
                    if(ita.Definizioni.Contains(eng.Sezione))
                        eng.Definizioni.Add(ita.Sezione);
                    else
                    {
                        paroleInglese.Add(new Nodo(ita.Sezione, true, 0));
                        paroleInglese.Last().Definizioni.Add(ita.Sezione);
                    }
                }
            }
            giovanni.CreaAlbero(paroleInglese.ToArray());
            italiano = !italiano;
        }

        public void SalvaParoleInFileDiTesto()
        {
            if(!italiano)
                traduciAlbero();
            using (StreamWriter sw = new StreamWriter("dizionario.txt"))
            {
                List<Nodo> nodi = Albero.TuttiFuori(giovanni);
                foreach (Nodo n in nodi)
                {
                    sw.Write(n.Sezione);
                    foreach (string s in n.Definizioni)
                    {
                        sw.Write(";" + s);
                    }
                    sw.WriteLine();
                }
            }
        }
        
        //converti il file di testo in un file binario da usare come backup
    }
}
