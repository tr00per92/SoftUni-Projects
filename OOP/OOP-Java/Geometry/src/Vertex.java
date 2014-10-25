public class Vertex {
    private double x;
    private double y;

    public Vertex(double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return this.x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return this.y;
    }

    public void setY(double y) {
        this.y = y;
    }

    public static double CalcDistance2D(Vertex a, Vertex b){
        double distance = Math.sqrt((a.getX() - b.getX()) * (a.getX() - b.getX()) +
                (a.getY() - b.getY()) * (a.getY() - b.getY()));
        return distance;
    }

    @Override
    public String toString() {
        return String.format("X: %s Y: %s", this.x, this.y);
    }
}
