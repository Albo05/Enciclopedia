using System.Collections.Generic;

namespace Dizionario
{
    public class Nodo
    {
        private string _sezione;
        private List<Nodo> _successivi;

        private bool _parola;
        private List<string> _definizioni;
        
        public string sezione
        {
            get { return _sezione; }
            set { _sezione = value; }
        }
        public List<Nodo> successivi
        {
            get { return _successivi; }
            set { _successivi = value; }
        }
        public bool parola
        {
            get { return _parola; }
            set { _parola = value; }
        }
        public List<string> definizioni
        {
            get { return _definizioni; }
            set { _definizioni = value; }
        }
        
        public Nodo(string sezione, bool parola)
        {
            this._sezione = sezione;
            this._parola = parola;
            _successivi = new List<Nodo>();
            if(_parola)
                _definizioni = new List<string>();
        }
        
        public bool AggiungiDefinizione(string definizione)
        {
            if(_parola && definizione != "" && definizione.Length <= 100 && !_definizioni.Contains(definizione.ToLower()) && definizione.Contains("^"))
            {
                _definizioni.Add(definizione.ToLower());
                return true;
            }
            return false;
        }
        
        public bool RimuoviDefinizione(string definizione)
        {
            if(_parola && _definizioni.Contains(definizione.ToLower()))
            {
                _definizioni.Remove(definizione.ToLower());
                return true;
            }
            return false;
        }

        public bool CancellaParola()
        {
            if(_parola)
            {
                _parola = false;
                _definizioni = null;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string stringa = _sezione + "^\n";
            foreach (var a in _definizioni)
            {
                stringa += a + "^\n";
            }
            return stringa;
        }
    }
}