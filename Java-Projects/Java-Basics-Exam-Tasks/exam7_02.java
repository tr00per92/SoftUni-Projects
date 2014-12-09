import java.util.Scanner;

public class exam7_02 {

	public static void main(String[] args) {
		String[] input = new Scanner(System.in).nextLine().split(" ");
		int[] nums = new int[input.length];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(input[i]);
		}
		long best = Integer.MIN_VALUE;
		int curr = 0, index = 0;
		for (int i = 0; i < nums.length; i++) {
			if (i % 3 == 0 && i != 0) {
				if (curr > best) {
					best = curr;
					index = i - 1;
				}
				curr = 0;
			}
			curr += nums[i];
		}
		index -= 2;
		if (curr > best) {
			int rem = nums.length % 3;
			if (rem == 0) rem = 3;
			index = nums.length - rem;
		}
		for (int i = 0; i < 3; i++) {
			if (index < nums.length) {
				System.out.print(nums[index] + " ");
			}
			index++;
		}
	}
}