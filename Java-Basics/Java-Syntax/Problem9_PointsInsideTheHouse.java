import java.awt.geom.Point2D;
import java.util.Locale;
import java.util.Scanner;

public class Problem9_PointsInsideTheHouse {
	
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner sc = new Scanner(System.in);
		Point2D.Double point = new Point2D.Double(sc.nextDouble(), sc.nextDouble());
		if (insideHouse(point)) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}		
	}		
	static boolean insideTriangle(Point2D.Double point) {
		Point2D.Double a = new Point2D.Double(12.5, 8.5);
		Point2D.Double b = new Point2D.Double(22.5, 8.5);
		Point2D.Double c = new Point2D.Double(17.5, 3.5);	
		double abc = Math.abs(a.x * (b.y - c.y) + b.x * (c.y - a.y) + c.x * (a.y - b.y));
		double abp = Math.abs(a.x * (b.y - point.y) + b.x * (point.y - a.y) + point.x * (a.y - b.y));
		double acp = Math.abs(a.x * (point.y - c.y) + point.x * (c.y - a.y) + c.x * (a.y - point.y));
		double bcp = Math.abs(point.x * (b.y - c.y) + b.x * (c.y - point.y) + c.x * (point.y - b.y));
		return abp + acp + bcp == abc;
	}
	static boolean insideHouse(Point2D.Double point) {
		boolean insideSquare = point.x >= 12.5 && point.x <= 17.5 && point.y <= 13.5 && point.y >= 8.5;
		boolean insideRectangle = point.x >= 20 && point.x <= 22.5 && point.y <= 13.5 && point.y >= 8.5;
		boolean insideHouse = insideRectangle || insideSquare || insideTriangle(point);
		return insideHouse;
	}
}
