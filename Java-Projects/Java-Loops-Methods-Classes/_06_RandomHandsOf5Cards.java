import java.util.Random;
import java.util.Scanner;

public class _06_RandomHandsOf5Cards {

	public static void main(String[] args) {
		Random rnd = new Random();
		String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		char[] suites = {'♣', '♦', '♥', '♠'};
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < 5; j++) {
				String randomFace = faces[rnd.nextInt(faces.length)];
				char randomSuit = suites[rnd.nextInt(suites.length)];
				System.out.print(randomFace + randomSuit + " ");
			}
			System.out.println();
		}		
	}

}
