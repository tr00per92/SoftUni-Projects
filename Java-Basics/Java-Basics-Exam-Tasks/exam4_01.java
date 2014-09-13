import java.util.Scanner;

public class exam4_01 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double result = 0;
		switch (input.next()) {
		case "Premiere": result = 12; break;
		case "Normal": result = 7.5; break;
		case "Discount": result = 5; break;
		}
		result *= input.nextInt() * input.nextInt();
		System.out.printf("%.2f leva", result);
	}
}