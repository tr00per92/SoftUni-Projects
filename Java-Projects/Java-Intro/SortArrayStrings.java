import java.util.Scanner;
import java.util.Arrays;

public class SortArrayStrings {
	 public static void main(String[] args) {
         Scanner scanner = new Scanner(System.in);
         int n = Integer.parseInt(scanner.nextLine());
         String[] words = new String[n];
         for(int i=0;i<n;i++)
         {
        	 words[i] = scanner.nextLine();
         }
         Arrays.sort(words);
         for(int i=0;i<n;i++)
         {
        	 System.out.println(words[i]);
         }
	 }
}

