import java.util.Scanner;

public class exam2_04 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int sum = input.nextInt();
		int diff = input.nextInt();
		boolean no = true;
		for (int i = 555; i < 1000; i++) {
			int i1 = i + diff;
			int i2 = i1 + diff;
			int digit1 = i % 10;
			int digit2 = (i / 10) % 10;
			int digit3 = i / 100;
			int digit4 = i1 % 10;
			int digit5 = (i1 / 10) % 10;
			int digit6 = i1 / 100;
			int digit7 = i2 % 10;
			int digit8 = (i2 / 10) % 10;
			int digit9 = i2 / 100;
			if (digit1>4&&digit1<10&&digit2>4&&digit2<10&&digit3>4&&digit3<10&&digit4>4&&digit4<10&&digit5>4&&digit5<10&&
					digit6>4&&digit6<10&&digit7>4&&digit7<10&&digit8>4&&digit8<10&&digit9>4&&digit9<10&&
					digit1+digit2+digit3+digit4+digit5+digit6+digit7+digit8+digit9 == sum) {
				no = false;
				System.out.println(i + "" + i1 + "" + i2);
			}
		}
		if(no) {
			System.out.println("No");
		}
	}
}