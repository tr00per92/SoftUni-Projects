import java.util.Arrays;
import java.util.Scanner;

public class _01_SortArrayOfNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int[] nums = new int[n];
		for (int i = 0; i < n; i++) {
			nums[i] = input.nextInt();
		}
		Arrays.sort(nums);
		for (int num : nums) {
			System.out.print(num + " ");
		}
	}
}
