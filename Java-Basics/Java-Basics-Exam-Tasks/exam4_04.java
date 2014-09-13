import java.util.ArrayList;
import java.util.Scanner;

public class exam4_04 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Integer> trib = new ArrayList<>();
		ArrayList<Integer> spiral = new ArrayList<>();
		trib.add(input.nextInt()); trib.add(input.nextInt()); trib.add(input.nextInt());
		spiral.add(input.nextInt());
		int step = input.nextInt();
		while (trib.get(trib.size() - 1) < 1000000) {
			trib.add(trib.get(trib.size()-1) + trib.get(trib.size()-2) + trib.get(trib.size()-3));
		}
		int temp = 1, temp1 = 0;
		while (spiral.get(spiral.size() - 1) < 1000000) {
			spiral.add(spiral.get(spiral.size() - 1) + step * temp);
			if (temp1 % 2 == 1){
				temp++;
			}
			temp1++;
		}
		boolean no = true;
		for (int i = 0; i <= 1000000; i++) {
			if (trib.contains(i) && spiral.contains(i)) {
				no = false;
				System.out.println(i);
				break;
			}
		}
		if (no) {
			System.out.println("No");
		}
	}
}