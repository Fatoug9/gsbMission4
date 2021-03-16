using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gsbFatou
{
     public class GestionDate
    {
        
        DateTime aujourdhui = DateTime.Now;
        public String dateJour()
        {
            String ajd = aujourdhui.ToString("yyyyMM");
            return ajd;
        }
       
        public String moisPrecedent()
        {
            String moisPrecedent = aujourdhui.AddMonths(-1).ToString("yyyyMM");

            
            return moisPrecedent;
        }

        public String moisSuivant()
        {
            String moisSuivant = aujourdhui.AddMonths(+1).ToString("yyyyMM");
            return moisSuivant;
        }


    }
}
