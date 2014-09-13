import java.util.Scanner;

public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] input = sc.nextLine().split(" ");
		int[] nums = new int[input.length];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(input[i]);
		}
		int bestSequenceIndex = 0;	//storing the start index of the longest sequence
		int currentSequence = 1;
		int bestSequence = 1;
		System.out.print(nums[0] + " ");
		for (int i = 1; i < nums.length; i++) {
			if (nums[i] > nums[i - 1]) {
				currentSequence++;
				System.out.print(nums[i] + " ");
				if (currentSequence > bestSequence) {
					bestSequence = currentSequence;
					bestSequenceIndex = i - bestSequence + 1;
				}
			}
			else {
				currentSequence = 1;
				System.out.println();
				System.out.print(nums[i] + " ");
			}
		}
		System.out.println();
		System.out.print("Longest: ");
		for (int i = 0; i < bestSequence; i++) {
			System.out.print(nums[bestSequenceIndex + i] + " ");
		}
	}
}