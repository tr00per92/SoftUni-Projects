import java.util.Scanner;

public class exam8_04 {

	public static void main(String[] args) {
		int n = new Scanner(System.in).nextInt() - 40;
		int[] letters = {10, 20, 30, 50, 80, 110, 130, 160, 200, 240};
		int count = 0;
		for (int i5 = 0; i5 < letters.length; i5++) {
			for (int i6 = 0; i6 < letters.length; i6++) {
				for (int i1 = 0; i1 <= 9; i1++) {
					for (int i2 = 0; i2 <= 9; i2++) {
						for (int i3 = 0; i3 <= 9; i3++) {
							for (int i4 = 0; i4 <= 9; i4++) {
								int curr = i1 + i2 + i3 + i4 + letters[i5] + letters[i6];
								if (curr == n) {
									if (i1 == i2) {
										if ((i3 == i4) || (i3 == i1 && i3 != i4)) {
											count++;
										}
									}
									else if ((i3 == i4 && i3 == i2) || (i1 == i3 && i2 == i4) || (i1 == i4 && i2 == i3)) {
											count++;										
									}
								}
							}
						}
					}
				}
			}
		}
		System.out.println(count);
	}
}