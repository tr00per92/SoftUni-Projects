public class Triangle extends PlaneShape {
    public Triangle(Vertex a, Vertex b, Vertex c) {
        super(a, b, c);
    }

    public Vertex getA() {
        return this.vertices[0];
    }

    public Vertex getB() {
        return this.vertices[1];
    }

    public Vertex getC() {
        return this.vertices[2];
    }

    public double getPerimeter() {
        double ab = Vertex.CalcDistance2D(this.getA(), this.getB());
        double bc = Vertex.CalcDistance2D(this.getB(), this.getC());
        double ac = Vertex.CalcDistance2D(this.getA(), this.getC());

        return ab + bc + ac;
    }

    public double getArea() {
        double area = Math.abs((
                this.getA().getX() * (this.getB().getY() - this.getC().getY()) +
                this.getB().getX() * (this.getC().getY() - this.getA().getY()) +
                this.getC().getX() * (this.getA().getY() - this.getB().getY())) / 2);
        return area;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("\nPoint A: %s\nPoint B: %s\nPoint C: %s",
                this.getA(), this.getB(), this.getC());
    }
}
