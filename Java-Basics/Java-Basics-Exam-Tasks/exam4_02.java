import java.util.Scanner;

public class exam4_02 {

	public static void main(String[] args) {
		char[] input = new Scanner(System.in).nextLine().toLowerCase().toCharArray();
		int count = 0, sum = 0;
		for (char c : input) {
			switch (c) {
			case 'a': count++; sum += 65; break;
			case 'e': count++; sum += 69; break;
			case 'i': count++; sum += 73; break;
			case 'o': count++; sum += 79; break;
			case 'u': count++; sum += 85; break;
			}
		}
		System.out.println(count);
		System.out.println(sum);
	}
}