import java.util.Scanner;

public class _02_Generate3LetterWords {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String input = scanner.next();
		for (int i = 0; i < input.length(); i++) {
			for (int j = 0; j < input.length(); j++) {
				for (int k = 0; k < input.length(); k++) {
					System.out.print(input.charAt(i));
					System.out.print(input.charAt(j));
					System.out.print(input.charAt(k));
					System.out.print(" ");
				}
			}
		}
	}
}