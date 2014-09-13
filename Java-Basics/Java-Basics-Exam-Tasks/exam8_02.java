import java.util.Scanner;

public class exam8_02 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int total = 0;
		boolean nextCable = false;
		int n = input.nextInt();
		for (int i = 0; i < n; i++) {
			int len = input.nextInt();
			if (input.next().equals("meters")) len *= 100;
			if (len >= 20) {
				if (nextCable) len -= 3;
				total += len;
				nextCable = true;
			}
		}
		System.out.println(total / 504);
		System.out.println(total % 504);
	}
}