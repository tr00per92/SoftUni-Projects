import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;

public class CouplesFrequency {
    public static void main(String[] args) {
        String[] input = new Scanner(System.in).nextLine().split(" ");
        LinkedHashMap<String, Integer> result = new LinkedHashMap<>();
        for (int i = 0; i < input.length - 1; i++) {
            String currentCouple = input[i] + " " + input[i + 1];
            if (!result.containsKey(currentCouple)) {
                result.put(currentCouple, 0);
            }
            result.put(currentCouple, result.get(currentCouple) + 1);
        }
        double weight = 100.0 / (input.length - 1);
        for (Entry couple : result.entrySet()) {
            System.out.printf("%s -> %.2f%%", couple.getKey(), (int)couple.getValue() * weight);
            System.out.println();
        }
    }
}
