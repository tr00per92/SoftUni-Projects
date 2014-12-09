import java.util.Scanner;

public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] text = sc.nextLine().toLowerCase().split("\\W+");
		String targetWord = sc.next().toLowerCase();
		int count = 0;
		for (String word : text) {
			if (word.equals(targetWord)) {
				count++;
			}
		}
		System.out.println(count);
	}
}
