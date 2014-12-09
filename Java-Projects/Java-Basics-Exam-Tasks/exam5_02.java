import java.util.Scanner;

public class exam5_02 {

	public static void main(String[] args) {
		String[] input = new Scanner(System.in).nextLine().split(" ");
		int diff = 0;
		int sum = Integer.parseInt(input[0]) + Integer.parseInt(input[1]);
		for (int i = 3; i < input.length; i += 2) {			
			int sum2 = Integer.parseInt(input[i]) + Integer.parseInt(input[i - 1]);
			int currDiff = Math.abs(sum - sum2);
			if (currDiff > diff) {
				diff = currDiff;
			}
			sum = sum2;
		}
		if (diff == 0){
			System.out.println("Yes, value=" + sum);			
		}
		else {
			System.out.println("No, maxdiff=" + diff);
		}
	}
}