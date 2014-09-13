import java.util.Scanner;

public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String text = sc.nextLine().toLowerCase();
		String target = sc.next().toLowerCase();
		int index = 0;  //used as a temp value which help iterating though all substrings
		int count = 0;
		while (index < text.length() - target.length() + 1) {
			if (text.substring(index, index + target.length()).equals(target)) {
				count++;
			}
			index++;
		}
		System.out.println(count);
	}
}