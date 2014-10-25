public class SquarePyramid extends SpaceShape {
    private double baseWidth;
    private double height;

    public SquarePyramid(Vertex3D baseCenter, double baseWidth, double height) {
        super(baseCenter);
        this.setBaseWidth(baseWidth);
        this.setHeight(height);
    }

    public double getBaseWidth() {
        return this.baseWidth;
    }

    public void setBaseWidth(double baseWidth) {
        this.baseWidth = Math.abs(baseWidth);
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        this.height = Math.abs(height);
    }

    public double getArea() {
        double slantLength = Math.sqrt(this.height * this.height + (this.baseWidth / 2.0) * (this.baseWidth / 2.0));
        double area = (this.baseWidth * this.baseWidth) + ((this.baseWidth + this.baseWidth) * slantLength);
        return area;
    }

    public double getVolume() {
        double volume = this.baseWidth * this.baseWidth * this.height / 3.0;
        return volume;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nBase Center: %s\nBase Width: %s\nHeight: %s",
                this.vertices[0], this.getBaseWidth(), this.getHeight());
    }
}
