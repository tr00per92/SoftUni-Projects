import java.util.Scanner;

public class exam2_02 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt() * 2;
		int sumodd = 0, sumeven = 0;
		for (int i = 0; i < n; i++) {
			if (i % 2 == 0) {
				sumodd += input.nextInt();
			}
			else {
				sumeven += input.nextInt();
			}
		}
		if (sumodd == sumeven) {
			System.out.println("Yes, sum=" + sumeven);
		}
		else {
			System.out.println("No, diff=" + Math.abs(sumodd - sumeven));
		}
	}
}