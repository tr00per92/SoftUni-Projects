using System;

namespace GeometryAPI
{
    public class ExtendendFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                {
                    Vector3D center = Vector3D.Parse(splitFigString[1]);
                    double radius = double.Parse(splitFigString[2]);
                    this.currentFigure = new Circle(center, radius);
                    break;
                }
                case "cylinder":
                {
                    Vector3D top = Vector3D.Parse(splitFigString[1]);
                    Vector3D bot = Vector3D.Parse(splitFigString[2]);
                    double radius = double.Parse(splitFigString[3]);
                    this.currentFigure = new Cylinder(top, bot, radius);
                    break;
                }
                default:
                {
                    base.ExecuteFigureCreationCommand(splitFigString);
                    break;
                }
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "normal":
                {
                    var figure = this.currentFigure as IFlat;
                    Console.WriteLine(figure == null ? "undefined" : string.Format("{0:0.00}", figure.GetNormal()));
                    break;
                }
                case "volume":
                {
                    var figure = this.currentFigure as IVolumeMeasurable;
                    Console.WriteLine(figure == null ? "undefined" : string.Format("{0:0.00}", figure.GetVolume()));
                    break;
                }
                case "area":
                {
                    var figure = this.currentFigure as IAreaMeasurable;
                    Console.WriteLine(figure == null ? "undefined" : string.Format("{0:0.00}", figure.GetArea()));
                    break;
                }
                default:
                {
                    base.ExecuteFigureInstanceCommand(splitCommand);
                    break;
                }
            }
        }
    }
}
