import java.util.Scanner;

public class _01_SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		int start = scanner.nextInt();
		int end = scanner.nextInt();
		for (int i = start; i <= end; i++) {
			boolean symmetric = true;			
			int length = Integer.toString(i).length();
			int divider = (int)Math.pow(10, length - 1);
			for (int j = 0; j < length / 2; j++) {
				int digitOne = i / divider;
				divider /= 10;
				int digitTwo = (int)(i / Math.pow(10.0, j)) % 10;
				if (digitOne != digitTwo){
					symmetric = false;
					break;
				}
			}			
			if (symmetric) {
				System.out.print(i + " ");
			}
		}
	}
}