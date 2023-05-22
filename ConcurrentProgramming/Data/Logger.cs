
namespace DataNS;

public class Logger
{
    public static Logger logger;
    
    public static Logger createLogger()
    {
        return new Logger();
    }

    public void initFile()
    {
        string path =
            $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/BallProperties.json";
        if(File.Exists(path)) {
            File.Delete(path);
        }
    }

    public void prepareDataToSave(int id,double xPos, double yPos, double speedX, double speedY)
    {

        string stringOfProperties =
            "\n" +
            "Ball ID: " + id + "\n" +
            "Current xPos: " + xPos.ToString("N2") + "\n" +
            "Current yPos: " + yPos.ToString("N2") + "\n" +
            "Current speedX: " + speedX.ToString("N2") + "\n" +
            "Current speedY: " + speedY.ToString("N2") + "\n";
            
        try
        {
            using StreamWriter file = new StreamWriter($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/BallProperties.json", append: true);
            file.Write(stringOfProperties);
            file.Close();
        }
        catch (IOException o)
        {
            
        }
    }
   
}