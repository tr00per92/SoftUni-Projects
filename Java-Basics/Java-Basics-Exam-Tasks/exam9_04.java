import java.util.Scanner;

public class exam9_04 {

	public static void main(String[] args) {
		int w = new Scanner(System.in).nextInt();
		int result = 0;
		for (int i = 1; i <= 10; i++) {
			for (int i1 = 1; i1 <= 4; i1++) {
				for (int i2 = 1; i2 <= 4; i2++) {
					for (int i3 = 1; i3 <= 4; i3++) {
						for (int i4 = 1; i4 <= 4; i4++) {
							for (int i5 = 1; i5 <= 4; i5++) {
								int current = i * 10 + (i + 1) * 20 + (i + 2) * 30 + (i + 3) * 40 + (i + 4) * 50 + i1 + i2 + i3 + i4 + i5;
								if (current == w) {
									result++;
								}
							}
						}
					}
				}
			}
		}
		System.out.println(result);
	}
}
