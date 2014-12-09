import java.util.Scanner;

public class exam3_04 {

	public static void main(String[] args) {
		int diff = new Scanner(System.in).nextInt();
		int[] values = {1, 4, 5, 3};
		boolean no = true;
		for (int i = 0; i < 4; i++) {
			for (int i1 = 0; i1 < 4; i1++) {
				for (int i2 = 0; i2 < 4; i2++) {
					for (int i3 = 0; i3 < 4; i3++) {
						int sumOne = values[i] + values[i1] + values[i2] + values[i3];
						for (int i4 = 0; i4 < 4; i4++) {
							for (int i5 = 0; i5 < 4; i5++) {
								for (int i6 = 0; i6 < 4; i6++) {
									for (int i7 = 0; i7 < 4; i7++) {
										int sumTwo = values[i4] + values[i5] + values[i6] + values[i7];
										if (diff == Math.abs(sumOne - sumTwo)){
											int[] temp = {values[i], values[i1], values[i2], values[i3],
													values[i4], values[i5], values[i6], values[i7]};
											printResult(temp);
											no = false;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if (no) {
			System.out.println("No");
		}
	}

	private static void printResult(int[] nums) {
		for (int i = 0; i < nums.length; i++) {
			switch (nums[i]) {
			case 1: System.out.print("k"); break;
			case 3: System.out.print("s"); break;
			case 4: System.out.print("n"); break;
			case 5: System.out.print("p"); break;
			}
		}
		System.out.println();
	}
}