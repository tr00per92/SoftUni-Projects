import java.util.Scanner;

public class Problem2_TriangleArea {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int xA = sc.nextInt();
		int yA = sc.nextInt();
		int xB = sc.nextInt();
		int yB = sc.nextInt();
		int xC = sc.nextInt();
		int yC = sc.nextInt();
		double area = Math.abs((xA * (yB - yC) + xB * (yC - yA) + xC * (yA - yB)) / 2);
		System.out.println(Math.round(area));
	}

}
