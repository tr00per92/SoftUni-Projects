import Interfaces.AreaMeasurable;

public abstract class Shape implements AreaMeasurable {
    protected Vertex[] vertices;

    protected Shape(Vertex... vertexes) {
        this.vertices = vertexes;
    }

    @Override
    public String toString() {
        return "Shape: " + this.getClass().getName();
    }
}
