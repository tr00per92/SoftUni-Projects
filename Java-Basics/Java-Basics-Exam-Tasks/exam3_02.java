import java.util.Scanner;

public class exam3_02 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] nums = input.nextLine().split(" ");
		int[] num = new int[nums.length];
		long result = Long.MAX_VALUE;
		boolean found = false;
		for (int i = 0; i < num.length; i++) {
			num[i] = Integer.parseInt(nums[i]);
		}
		for (int i = 0; i < num.length; i++) {
			int current = num[i];
			long sum = 0;
			for (int j = 0; j < num.length; j++) {
				if (i != j) {
					sum += num[j];
				}
			}
			if (current == sum) {
				result = sum;
				found = true;
				break;
			}
			else {
				long diff = Math.abs(current - sum);
				if (diff < result) {
					result = diff;
				}
			}
		}
		System.out.println(found ? "Yes, sum=" + result: "No, diff=" + result);
	}
}