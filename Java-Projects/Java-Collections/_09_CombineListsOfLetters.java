import java.util.ArrayList;
import java.util.Scanner;

public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] line1 = input.nextLine().split(" ");
		String[] line2 = input.nextLine().split(" ");
		// filling the first list with the first line
		ArrayList<Character> list1 = new ArrayList<>();
		for (String s: line1) {
			list1.add(s.charAt(0));
		}
		// filling the second list
		ArrayList<Character> list2 = new ArrayList<>();
		for (String s: line2) {
			list2.add(s.charAt(0));
		}
		// adding missing values from second list to first list
		for (char c: list2) {
			if (!list1.contains(c)){
				list1.add(c);
			}
		}
		// printing the final list
		for (char c: list1) {
			System.out.print(c + " ");
		}
	}
}