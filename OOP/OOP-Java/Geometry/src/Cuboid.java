public class Cuboid extends  SpaceShape{
    private double width;
    private double height;
    private double depth;

    public Cuboid(Vertex3D a, double width, double height, double depth) {
        super(a);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
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

    public double getDepth() {
        return this.depth;
    }

    public void setDepth(double depth) {
        this.depth = Math.abs(depth);
    }

    public double getArea() {
        double area = 2 * (this.depth * this.width + this.depth * this.height + this.height * this.width);
        return area;
    }

    public double getVolume() {
        double volume = this.depth * this.width * this.height;
        return volume;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nPoint A: %s\nWidth: %s\nHeight: %s\nDepth: %s",
                this.vertices[0], this.getWidth(), this.getHeight(), this.getDepth());
    }
}
