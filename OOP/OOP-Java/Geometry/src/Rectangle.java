public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(Vertex a, double width, double height) {
        super(a);
        this.setWidth(width);
        this.setHeight(height);
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        this.width = Math.abs(width);
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        this.height = Math.abs(height);
    }

    public double getArea() {
        return this.width * this.height;
    }

    public double getPerimeter() {
        return 2 * this.height + 2 * this.width;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nPoint A: %s\nWidth: %s\nHeight: %s",
                this.vertices[0], this.getWidth(), this.getHeight());
    }
}
