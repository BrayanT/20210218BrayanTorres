using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using DAL;

namespace BL
{
    public class LibrosBL
    {
        public List<clsLibro> Obtener()
        {
            return LibrosDAL.Obtener();
        }
    }
}
