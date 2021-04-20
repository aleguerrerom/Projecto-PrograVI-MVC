using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
  static  class Program
    {
        static void Main()
        {
            WSMail vloServicio = new WSMail();
            vloServicio.Iniciar();
           System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
