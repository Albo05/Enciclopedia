using System.Collections.Generic;

namespace Dizionario
{
    public class Nodo
    {
        private string _sezione;
        private List<Nodo> _successivi;

        private bool _parola;
        private List<string> _traduzioni;

        private int _livello;
        
        public string Sezione
        {
            get { return _sezione; }
            set { _sezione = value; }
        }
        public List<Nodo> Successivi
        {
            get { return _successivi; }
            set { _successivi = value; }
        }
        public bool Parola
        {
            get { return _parola; }
            set { _parola = value; }
        }
        public List<string> Definizioni
        {
            get { return _traduzioni; }
            set { _traduzioni = value; }
        }

        public int Livello
        {
            get {return _livello; }
            set {_livello = value; }
        }
        
        public Nodo(string sezione, bool parola, int livello)
        {
            this._sezione = sezione;
            this._parola = parola;
            _successivi = new List<Nodo>();
            if(_parola)
                _traduzioni = new List<string>();
            this._livello = livello;
        }
        
        public bool AggiungiDefinizione(string definizione)
        {
            if(_parola && definizione != "" && definizione.Length <= 100 && !_traduzioni.Contains(definizione.ToLower()) && definizione.Contains("^"))
            {
                _traduzioni.Add(definizione.ToLower());
                return true;
            }
            return false;
        }
        
        public bool RimuoviDefinizione(string definizione)
        {
            if(_parola && _traduzioni.Contains(definizione.ToLower()))
            {
                _traduzioni.Remove(definizione.ToLower());
                return true;
            }
            return false;
        }

        public bool CancellaParola()
        {
            if(_parola)
            {
                _parola = false;
                _traduzioni = null;
                return true;
            }
            return false;
        }
        
        public string DefinizioniToString()
        {
            string stringa = "";
            foreach (var a in _traduzioni)
            {
                stringa +="- " + a + "\n";
            }
            return stringa;
        }

        public override string ToString()
        {
            string stringa = _sezione + "^";
            foreach (var a in _traduzioni)
            {
                stringa += a + "^";
            }
            stringa += "\n";
            return stringa;
        }
    }
}