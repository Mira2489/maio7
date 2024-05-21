using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maio7.Controllers
{
    internal class Biblioteca
    {
        public static string trocaSelos(int euros)
        {
            string resposta = "";
            int s3 = 0, s5 = 0, quoc, r;
            if (euros >= 8)
            {
                quoc = euros / 8;
                r = euros % 8;
                switch (r)
                {
                    case 0: s3 = quoc; s5 = quoc; break;
                    case 1: s3 = quoc + 2; s5 = quoc - 1; break;
                    case 2: s3 = quoc - 1; s5 = quoc + 1; break;
                    case 3: s3 = quoc + 1; s5 = quoc; break;
                    case 4: s3 = quoc + 3; s5 = quoc - 1; break;
                    case 5: s3 = quoc; s5 = quoc + 1; break;
                    case 6: s3 = quoc + 2; s5 = quoc; break;
                    case 7: s3 = quoc - 1; s5 = quoc + 2; break;
                }
            }
            else
            {
                if (euros == 3) s3 = 1;
                else if (euros == 5) s5 = 1;
                else if (euros == 6) s3 = 2;
                else resposta = "Devolução da Quantia ";
            }
            resposta += $" S5::{s5} S3::{s3} ";
            return resposta;
        }
    }
}
