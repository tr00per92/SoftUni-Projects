public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(Vertex3D center, double radius) {
        super(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    public void setRadius(double radius) {
        this.radius = Math.abs(radius);
    }

    public double getArea() {
        double area = Math.PI * 4 * this.radius * this.radius;
        return area;
    }

    public double getVolume() {
        double volume = Math.PI * this.radius * this.radius * this.radius * 4 / 3.0;
        return volume;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nCenter: %s\nRadius: %s",
                this.vertices[0], this.getRadius());
    }
}
