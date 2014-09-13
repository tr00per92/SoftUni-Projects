import java.util.Scanner;
import java.util.TreeSet;

public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().toLowerCase().split("\\W+");
		TreeSet <String> uniqueWords = new TreeSet<>();
		// filling all the words in the set
		for (String word: words) {
			uniqueWords.add(word);
		}
		// printing result
		for (String word: uniqueWords) {
			System.out.print(word + " ");
		}
	}
}