
namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateApi()
        {
            return new DataAPI();
        }
    }

    public class DataAPI : DataAbstractAPI
    {

    }
}
