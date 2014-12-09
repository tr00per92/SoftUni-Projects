import java.util.Locale;
import java.util.Scanner;

public class Problem6_FormattingNumbers {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner sc = new Scanner(System.in);
		int a = sc.nextInt();
		String hexA = Integer.toHexString(a).toUpperCase();
		long binaryA = Long.parseLong(Integer.toBinaryString(a));
		double b = sc.nextDouble();
		double c = sc.nextDouble();
		System.out.printf("|%-10s|%010d|%10.2f|%-10.3f|", hexA, binaryA, b, c);
		System.out.println();
	}
}
