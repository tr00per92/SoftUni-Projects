import java.util.Scanner;

public class exam7_03 {

	public static void main(String[] args) {
		int n = new Scanner(System.in).nextInt();
		String line = "";
		for (int i = 0; i < n / 2; i++) {
			line = new String(new char[i]).replace("\0", ".") + "\\" +
					new String(new char[n-2-2*i]).replace("\0", "*") + "/" +
					new String(new char[i]).replace("\0", ".");
			System.out.println(line);
		}
		int count = n < 12 ? n / 2 - 1 : n / 2 - 2;
		line = new String(new char[n/2-1]).replace("\0", ".") + "||" + new String(new char[n/2-1]).replace("\0", ".");
		for (int i = 0; i < count; i++) {
			System.out.println(line);
		}
		count = n/2 - count;
		line = new String(new char[n]).replace("\0", "-");
		for (int i = 0; i < count; i++) {
			System.out.println(line);
		}
	}
}