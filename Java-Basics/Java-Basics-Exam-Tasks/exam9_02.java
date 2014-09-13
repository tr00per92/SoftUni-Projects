import java.util.ArrayList;
import java.util.Scanner;

public class exam9_02 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] input = sc.nextLine().split(" ");
		int k = sc.nextInt();
		ArrayList<Integer> nums = new ArrayList<>();
		for (int i = 0; i < input.length; i++) {
			nums.add(Integer.parseInt(input[i]));
		}
		ArrayList<Integer> result = new ArrayList<>();
		result.addAll(nums);
		int count = 1;
		for (int i = 1; i < nums.size(); i++) {
			if (nums.get(i).equals(nums.get(i-1))) {
				count++;
			}
			else {
				count = 1;
			}
			if (count == k) {
				for (int j = 0; j < k; j++) {
					result.remove(nums.get(i));
				}
				count = 0;
			}
		}
		for (Integer i : result) {
			System.out.print(i + " ");
		}
	}
}