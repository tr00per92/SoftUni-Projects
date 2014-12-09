import Interfaces.VolumeMeasurable;

public abstract class SpaceShape extends Shape implements VolumeMeasurable {
    protected SpaceShape(Vertex3D... vertexes) {
        super(vertexes);
    }
}
