import java.util.Scanner;

public class exam3_01 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int h = input.nextInt();
		int d = input.nextInt();
		int p = input.nextInt();
		double hours = d * 0.9 * 12 * (p / 100.0);
		int diff = (int)hours - h;
		System.out.println(diff >= 0 ? "Yes" : "No");
		System.out.println(diff);
	}
}