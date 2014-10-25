import Interfaces.PerimeterMeasurable;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable {
    protected PlaneShape(Vertex... vertexes) {
        super(vertexes);
    }
}
