import java.util.Locale;
import java.util.Scanner;

public class Problem3_PointsInsideFigure {
	
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner sc = new Scanner(System.in);
		double x = sc.nextDouble();
		double y = sc.nextDouble();
		if (insideFirstRectangle(x , y) || insideSecondRectangle (x , y) || insideThirdRectangle(x , y)) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
	}	
	static boolean insideFirstRectangle (double x, double y) {
		return x >= 12.5 && x <= 22.5 && y <= 8.5 && y >= 6;
	}
	static boolean insideSecondRectangle (double x, double y) {
		return x >= 20 && x <= 22.5 && y <= 13.5 && y >= 8.5;
	}
	static boolean insideThirdRectangle (double x, double y) {
		return x >= 12.5 && x <= 17.5 && y <= 13.5 && y >= 8.5;
	}		
}
