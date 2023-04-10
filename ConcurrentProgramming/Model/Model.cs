using Logic;

namespace Model
{
    public class Model
    {
        private readonly int canvasWidth;
        private readonly int canvasHeight;
        private readonly LogicAbstractAPI logicAbstractAPI;

       public Model(int canvasWidth, int canvasHeight,LogicAbstractAPI logicAbstractAPI) {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            this.logicAbstractAPI = logicAbstractAPI;
        }
    }
}