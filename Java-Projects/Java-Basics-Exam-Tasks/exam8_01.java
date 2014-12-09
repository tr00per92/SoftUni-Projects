import java.awt.Point;
import java.util.Scanner;

public class exam8_01 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int h = input.nextInt();
		for (int i = 0; i < 5; i++) {
			Point p = new Point(input.nextInt(), input.nextInt());
			boolean bot = p.x >= 0 && p.y >= 0 && p.x <= 3*h && p.y <= h;
			boolean top = p.x >= h && p.y >= h && p.x <= 2*h && p.y <= 4*h;
			if (bot || top) {
				System.out.println("inside");
			}
			else {
				System.out.println("outside");
			}
		}
	}
}