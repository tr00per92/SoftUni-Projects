import java.util.Scanner;

public class exam2_01 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		boolean leap = (input.next().equals("leap"));
		int p = input.nextInt();
		int h = input.nextInt();
		double result = p * (2.0/3.0) + h + (48-h) * (3.0/4.0);
		if (leap) {
			result *= 1.15;
		}
		System.out.println((int)result);
	}
}
