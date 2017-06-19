using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImageDAL
    {
        University2Entities obj = new University2Entities();
        public List<Image> GetImages()
        {
            try
            {
                var data = (from c in obj.Images
                            select c).ToList<Image>();
                return data;
            }
           catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
