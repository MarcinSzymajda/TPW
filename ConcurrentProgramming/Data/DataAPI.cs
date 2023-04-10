using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI createApi()
        {
            return new DataAbstractAPI();
        }
    }

    public internal class DataAPI : DataAbstractAPI
    {

    }
}
