import java.util.Scanner;

public class _05_CountAllWords {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] input = sc.nextLine().split("\\W+");
		System.out.println(input.length);
	}
}