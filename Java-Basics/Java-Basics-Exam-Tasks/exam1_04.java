import java.util.Scanner;

public class exam1_04 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int sum = input.nextInt();
		int diff = input.nextInt();
		boolean no = true;
		for (int i1 = 1; i1 <= 7; i1++) {			
			for (int i2 = 1; i2 <= 7; i2++) {
				for (int i3 = 1; i3 <= 7; i3++) {
					for (int i4 = 1; i4 <= 7; i4++) {
						for (int i5 = 1; i5 <= 7; i5++) {
							for (int i6 = 1; i6 <= 7; i6++) {
								for (int i7 = 1; i7 <= 7; i7++) {
									for (int i8 = 1; i8 <= 7; i8++) {
										for (int i9 = 1; i9 <= 7; i9++) {
											if (i1+i2+i3+i4+i5+i6+i7+i8+i9 == sum) {
												int first = Integer.parseInt(i1 + "" + i2 + "" +i3);
												int second = Integer.parseInt(i4 + "" + i5 + "" +i6);
												int third = Integer.parseInt(i7 + "" + i8 + "" +i9);
												if (second - first == diff && third - second == diff){
													no = false;
													System.out.println(first + "" + second + "" + third);
												}												
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if(no) {
			System.out.println("No");
		}
	}
}
