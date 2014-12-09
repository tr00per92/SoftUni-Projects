import java.util.Scanner;

public class Problem7_CountOfBitsOne {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int num = sc.nextInt();
		System.out.println(Integer.bitCount(num));
	}

}
