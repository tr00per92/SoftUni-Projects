import java.util.Scanner;

public class exam6_04 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int start = input.nextInt();
		int end = input.nextInt();
		boolean no = true;
		int[] values = {5, -12, 47, 7, -32};
		for (int i1 = 0; i1 < 5; i1++) {
			for (int i2 = 0; i2 < 5; i2++) {
				for (int i3 = 0; i3 < 5; i3++) {
					for (int i4 = 0; i4 < 5; i4++) {
						for (int i5 = 0; i5 < 5; i5++) {
							int sum = values[i1];
							int temp = 0;
							if (i2 != i1) sum += values[i2] * 2; else temp++;
							if (i3 != i2 && i3 != i1) sum += values[i3] * (3 - temp); else temp++;
							if (i4 != i3 && i4 != i2 && i4 != i1) sum += values[i4] * (4 - temp);  else temp++;
							if (i5 != i4 && i5 != i3 && i5 != i2 && i5 != i1) sum += values[i5] * (5 - temp);													
							if (sum >= start && sum <= end) {
								int[] result = {i1, i2, i3, i4, i5};
								Print(result);
								no = false;
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
	private static void Print (int[] result) {
		for (int i = 0; i < result.length; i++) {
			switch (result[i]) {
			case 0: System.out.print("a"); break;
			case 1: System.out.print("b"); break;
			case 2: System.out.print("c"); break;
			case 3: System.out.print("d"); break;
			case 4: System.out.print("e"); break;
			}
		}
		System.out.print(" ");
	}
}