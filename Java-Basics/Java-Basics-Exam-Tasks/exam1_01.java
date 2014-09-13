import java.util.Scanner;

public class exam1_01 {

	public static void main(String[] args) {
		double result = 0;
		Scanner input = new Scanner(System.in);
		if (input.next().equals("t")) {
			result += 3;
		}
		result += input.nextInt() * 0.5;
		int h = input.nextInt();
		result += (52 - h) * (2.0 / 3.0) + h;
		System.out.println((int)result);
	}

}
