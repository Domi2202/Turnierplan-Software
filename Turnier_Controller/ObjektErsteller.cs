using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Turnier_Prefabs;

namespace Turnier_Controller
{
    public abstract class ObjektErsteller
    {
        protected List<DialogFeld> Dialog_Felder { get; set; }
        public string Dialogtyp { get; set; }
        public ObjektErsteller()
        {
            Dialog_Felder = new List<DialogFeld>();
        }
        public abstract List<DialogFeld> Dialogfelder_bereitstellen();

        public abstract void Anfrage_entgegennehmen();

        protected DialogFeld Suche_Feld(string gesuchter_name)
        {
            IEnumerable<DialogFeld> gefundene_treffer = Dialog_Felder.Where(x => x.Get_Name() == gesuchter_name);
            try
            {
                DialogFeld gesuchtes_feld = gefundene_treffer.First();
                return gesuchtes_feld;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine("Der gesuchte Datesatz ist nich vorhanden!", e.Message);
                return null;
            }
        }
    }
}
