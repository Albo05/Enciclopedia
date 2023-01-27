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
        
        public Form1()
        {
            InitializeComponent();
        }

        public void caricaParole() //vado a caricare le parole dal file di testo 
        {
            //nome programma: gugol translate
            
            //creare una finestra degli errori dove vengono visualizzati eventuali errori nel carivamento del file
            
            //premi cerca per visualizzare una tra le nostre {numero di parole nell'albero} parole
            
            //quando creo un nuovo nodo prendendo i dati dal file devo ricordarmi di porre la variabile booleana di controllo "parola" come "true"
            
            using (StreamReader sr = new StreamReader("dizionario.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string riga = sr.ReadLine();
                    bool inserita = false;
                    string parola = riga.Split(',')[1];
                    while (inserita)
                    {
                        //if(dove.)
                    }
                }
            }
        }
    }
}
