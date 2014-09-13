import java.util.Collections;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class _11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		// reading the input
		String[] words = input.nextLine().toLowerCase().split("\\W+");
		TreeMap<String, Integer> wordFrequences = new TreeMap<>();
		// filling the map
		for (String word : words) {
			if (wordFrequences.containsKey(word)) {
				wordFrequences.put(word, wordFrequences.get(word) + 1);
			}
			else {
				wordFrequences.put(word, 1);
			}
		}
		// getting the max value of the map
		int max = Collections.max(wordFrequences.values());
		// printing results if the value is equal to max value
		for (Entry<String, Integer> pair : wordFrequences.entrySet()) {
			if (pair.getValue() == max) {
				System.out.println(pair.getKey() + " -> " + pair.getValue() + " times");
			}
		}
	}
}