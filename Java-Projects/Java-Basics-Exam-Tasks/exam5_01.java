import java.awt.Point;
import java.util.Scanner;

public class exam5_01 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);		
		Point a = new Point(input.nextInt(), input.nextInt());
		Point b = new Point(input.nextInt(), input.nextInt());
		Point c = new Point(input.nextInt(), input.nextInt());
		double ab = a.distance(b);
		double ac = a.distance(c);
		double bc = b.distance(c);
		boolean yes = ab < ac + bc && ac < ab + bc && bc < ab + ac;
		if (yes) {
			System.out.println("Yes");
			double p = (ab + ac + bc) / 2;
			System.out.printf("%.2f", Math.sqrt(p * (p - ab) * (p - ac) * (p - bc)));
		}
		else {
			System.out.println("No");
			System.out.printf("%.2f", ab);
		}
	}
}