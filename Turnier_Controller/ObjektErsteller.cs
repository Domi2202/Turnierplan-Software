using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
