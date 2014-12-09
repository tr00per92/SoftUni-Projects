import java.util.Locale;
import java.util.Scanner;

public class Problem4_TheSmallestOf3Numbers {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner sc = new Scanner(System.in);
		double a = sc.nextDouble();
		double b = sc.nextDouble();
		double c = sc.nextDouble();
		System.out.println(Math.min(Math.min(a, b), c));
	}

}
