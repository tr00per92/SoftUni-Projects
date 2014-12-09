import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class Test {
    public static void main(String[] args) {
        Vertex a = new Vertex(1, 2);
        Vertex b = new Vertex(2, 3);
        Vertex c = new Vertex(1, 5);

        Triangle myTriangle = new Triangle(a, b, c);
        Circle myCircle = new Circle(a, 5.5);
        Rectangle myRectangle = new Rectangle(c, 7, 6.5);

        Vertex3D d = new Vertex3D(1, 3, 5.5);
        SquarePyramid myPyramid = new SquarePyramid(d, 4, 6);
        Sphere mySphere = new Sphere(d, 8.5);
        Cuboid myCuboid = new Cuboid(d, 4, 8, 5.5);

        List<Shape> allShapes = Arrays.asList(myTriangle, myCircle, myRectangle, myPyramid, mySphere, myCuboid);
        for (Shape shape : allShapes) {
            System.out.println(shape);
            System.out.println("Area: " + shape.getArea());

            if (shape instanceof PlaneShape) {
                System.out.println("Perimeter: " + ((PlaneShape) shape).getPerimeter());
            } else if (shape instanceof SpaceShape) {
                System.out.println("Volume: " + ((SpaceShape) shape).getVolume());
            }

            System.out.println();
        }

        List<Shape> volumeOverForty = allShapes
                .stream()
                .filter(shape -> shape instanceof SpaceShape)
                .filter(shape -> ((SpaceShape)shape).getVolume() > 40)
                .collect(Collectors.toList());
        volumeOverForty.forEach(shape -> System.out.println(
                shape.getClass().getName() + " -> Volume: " + ((SpaceShape)shape).getVolume()));

        List<Shape> sortedByPerimeter = allShapes
                .stream()
                .filter(shape -> shape instanceof PlaneShape)
                .sorted((shape1, shape2) -> Double.compare(
                        ((PlaneShape)shape1).getPerimeter(),
                        ((PlaneShape)shape2).getPerimeter()))
                .collect(Collectors.toList());
        sortedByPerimeter.forEach(shape -> System.out.println(
                shape.getClass().getName() + " -> Perimeter: " + ((PlaneShape)shape).getPerimeter()));
    }
}
