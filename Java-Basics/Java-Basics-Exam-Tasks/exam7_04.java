import java.util.Scanner;

public class exam7_04 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		char[] w = input.next().toCharArray();
		int n = input.nextInt();
		char[][] block = new char[n][n];
		int index = 0;
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				block[i][j] = w[index];
				index++;
				if (index >= w.length) index = 0;
			}
		}
		String longest = "";
		String current = "";
		char last = 0;
		for (int row = 0; row < n; row++) {
			current = "";
			last = 0;
        	for (int col = 0; col < n; col++) {
        		if (block[row][col] > last) {
        			current += block[row][col];
        		}
        		else {
        			current = "" + block[row][col];
        		}
        		last = block[row][col];
            	if (current.length() > longest.length()) {
            		longest = current;
            	}
            	else if (current.length() == longest.length()) {
            		if (current.compareTo(longest) < 0) {
            			longest = current;
            		}
            	}
        	}
    	}
		for (int row = 0; row < n; row++) {
			current = "";
			last = 0;
        	for (int col = n - 1; col >= 0; col--) {
        		if (block[row][col] > last) {
        			current += block[row][col];
        		}
        		else {
        			current = "" + block[row][col];
        		}
        		last = block[row][col];
            	if (current.length() > longest.length()) {
            		longest = current;
            	}
            	else if (current.length() == longest.length()) {
            		if (current.compareTo(longest) < 0) {
            			longest = current;
            		}
            	}
        	}
    	}
		for (int col = 0; col < n; col++) {
			current = "";
			last = 0;
        	for (int row = n - 1; row >= 0; row--) {
        		if (block[row][col] > last) {
        			current += block[row][col];
        		}
        		else {
        			current = "" + block[row][col];
        		}
        		last = block[row][col];
            	if (current.length() > longest.length()) {
            		longest = current;
            	}
            	else if (current.length() == longest.length()) {
            		if (current.compareTo(longest) < 0) {
            			longest = current;
            		}
            	}
        	}
    	}
		for (int col = 0; col < n; col++) {
			current = "";
			last = 0;
        	for (int row = 0; row < n; row++) {
        		if (block[row][col] > last) {
        			current += block[row][col];
        		}
        		else {
        			current = "" + block[row][col];
        		}
        		last = block[row][col];
            	if (current.length() > longest.length()) {
            		longest = current;
            	}
            	else if (current.length() == longest.length()) {
            		if (current.compareTo(longest) < 0) {
            			longest = current;
            		}
            	}
        	}
    	}
		System.out.println(longest);
	}
}