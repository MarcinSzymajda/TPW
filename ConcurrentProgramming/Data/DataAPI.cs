
namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI createApi()
        {
            return new DataAPI();
        }
    }

    public class DataAPI : DataAbstractAPI
    {

    }
}
