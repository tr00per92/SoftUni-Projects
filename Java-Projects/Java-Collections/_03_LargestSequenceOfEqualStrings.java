import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] input = sc.nextLine().split(" ");
		String result = input[0];
		int currentCount = 1;
		int bestCount = 1;
		for (int i = 1; i < input.length; i++) {
			if(input[i].equals(input[i-1])) {
				currentCount++;
				if (currentCount > bestCount) {
					bestCount = currentCount;
					result = input[i];
				}
			}
			else {
				currentCount = 1;
			}
		}
		for (int i = 0; i < bestCount; i++) {
			System.out.print(result + " ");
		}
	}
}