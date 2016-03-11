﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Veranstaltung
    {
        public string name;
        public int anzahl_spielfelder;
        public List<Turnier> turniere;
        public List<Spieltag> spieltage;
        public List<Slot> spielplan;
    }

}
