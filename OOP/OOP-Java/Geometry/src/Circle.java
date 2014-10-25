public class Circle extends PlaneShape {
    private double radius;

    public Circle(Vertex center, double radius) {
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
        return Math.PI * this.radius * this.radius;
    }

    public double getPerimeter() {
        return Math.PI * this.radius * 2;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nCenter: %s\nRadius: %s",
                this.vertices[0], this.getRadius());
    }
}
