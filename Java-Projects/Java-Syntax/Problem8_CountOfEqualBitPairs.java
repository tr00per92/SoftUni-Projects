import java.util.Scanner;

public class Problem8_CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int num = sc.nextInt();
		int counter = 0;
		while ((num >> 1) != 0) {
			if ((num & 1) == 1 && ((num >> 1) & 1) == 1) {
				counter++;
			}
			else if ((num & 1) == 0 && ((num >> 1) & 1) == 0) {
				counter++;
			}
			num >>= 1;
		}
		System.out.println(counter);
	}

}
