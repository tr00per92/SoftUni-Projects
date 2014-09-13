import java.util.Locale;
import java.util.Scanner;

public class _05_AngleUnitConverter {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner scanner = new Scanner(System.in);
		int n = scanner.nextInt();
		for (int i = 0; i < n; i++) {
			double value = scanner.nextDouble();
			String measure = scanner.next();
			switch (measure) {
			case "deg": System.out.printf("%.6f rad\n", DegToRad(value)); break;
			case "rad": System.out.printf("%.6f deg\n", RadToDeg(value)); break;
			default: System.out.println("Error!"); break;
			}
		}
	}
	static double DegToRad (double deg) {
		return deg * 0.0174532925;
	}
	static double RadToDeg (double rad) {
		return rad * 57.2957795;
	}
}