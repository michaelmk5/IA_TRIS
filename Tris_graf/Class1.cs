using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tris_graf
{
    static class Comandi
    {
        public static string Vincita(List<string> giocate)
        {
            int[,] vincita = { {0,1,2},{3,4,5},{6,7,8},
            {0,3,6}, {1,4,7}, {2,5,8}, {0,4,8},{2,4,6}};
            string[] segni = new string[9];
            segni = giocate.ToArray();
            string result = null;
            string winner = "";
            for (int i = 0; i < 8; i++)
            {
                result = segni[vincita[i, 0]] + segni[vincita[i, 1]] + segni[vincita[i, 2]];
                if (result.Equals("XXX"))
                {
                    winner = "Il vincitore è il giocatore: X";
                    break;
                }
                else if (result.Equals("OOO"))
                {
                    winner = "Il vincitore è il giocatore: O";
                    break;
                }
            } 
            return winner;

        }
        public static IEnumerable<Control> getAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => getAll(ctrl, type)).Concat(controls).Where(c => c.GetType () == type);
        }

    }
}

