import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.Map.Entry;

public class _12_CardsFrequencies {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		// reading input
		String[] cards = input.nextLine().split("\\W+");
		double singleCardWeigth = 100.0 / cards.length;
		LinkedHashMap<String, Double> cardFrequences = new LinkedHashMap<>();
		// filling the map
		for (String card : cards) {
			if (cardFrequences.containsKey(card)) {
				cardFrequences.put(card, cardFrequences.get(card) + singleCardWeigth);
			}
			else {
				cardFrequences.put(card, singleCardWeigth);
			}
		}
		// printing results
		for (Entry<String, Double> pair : cardFrequences.entrySet()) {
				System.out.printf("%s -> %.2f%%", pair.getKey(), pair.getValue());
				System.out.println();
		}
	}
}