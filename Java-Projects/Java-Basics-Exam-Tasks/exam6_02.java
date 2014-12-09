import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class exam6_02 {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		String[] input = new Scanner(System.in).nextLine().split(" ");
		if (input[0].equals("")) {
			System.out.println("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
		}
		else if (input.length == 1) {
			DecimalFormat df = new DecimalFormat("#.##############");
			System.out.printf("OddSum=%s, OddMin=%s, OddMax=%s, EvenSum=No, EvenMin=No, EvenMax=No",
					df.format(Double.parseDouble(input[0])), df.format(Double.parseDouble(input[0])), df.format(Double.parseDouble(input[0])));
		}
		else {
			BigDecimal oddsum = new BigDecimal("0"), evensum = new BigDecimal("0");
			double oddmin = Integer.MAX_VALUE, oddmax = Integer.MIN_VALUE;
			double evenmin = Integer.MAX_VALUE, evenmax = Integer.MIN_VALUE;
			for (int i = 0; i < input.length; i++) {
				if (i % 2 == 0) {
					double odd = Double.parseDouble(input[i]);
					oddsum = oddsum.add(BigDecimal.valueOf(odd));
					oddmax = Math.max(odd, oddmax);
					oddmin = Math.min(odd, oddmin);
				}
				else {
					double even = Double.parseDouble(input[i]);
					evensum = evensum.add(BigDecimal.valueOf(even));
					evenmax = Math.max(even, evenmax);
					evenmin = Math.min(even, evenmin);
				}
			}
			DecimalFormat df = new DecimalFormat("#.##############");
			System.out.printf("OddSum=%s, OddMin=%s, OddMax=%s, EvenSum=%s, EvenMin=%s, EvenMax=%s",
					df.format(oddsum), df.format(oddmin), df.format(oddmax), df.format(evensum), df.format(evenmin), df.format(evenmax));
		}
	}
}