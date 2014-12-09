import java.util.Locale;
import java.util.Scanner;

public class exam7_01 {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		double result = 0;
		String day = input.next();
		for (int i = 0; i < 3; i++) {
			double q = input.nextDouble();
			double current = 0;
			switch (input.next()) {
			case "banana": current = 1.8 * q; 
				if(day.equals("Thursday")) current *= 0.7; 
				else if(day.equals("Tuesday")) current *= 0.8; break;
			case "cucumber": current = 2.75 * q;
				if(day.equals("Wednesday")) current *= 0.9; break;
			case "tomato": current = 3.2 * q;
				if(day.equals("Wednesday")) current *= 0.9; break;
			case "orange": current = 1.6 * q; 
				if(day.equals("Tuesday")) current *= 0.8; break;
			case "apple": current = 0.86 * q;
				if(day.equals("Tuesday")) current *= 0.8; break;
			}
			result += current;
		}
		if (day.equals("Friday")) result *= 0.9;
		else if (day.equals("Sunday")) result *= 0.95;
		System.out.printf("%.2f", result);
	}
}