import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class _07_DaysBetweenTwoDates {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		SimpleDateFormat format = new SimpleDateFormat("d-MM-yyyy");
		try {
			Date firstDate = format.parse(input.nextLine());
			Date secondDate = format.parse(input.nextLine());
			double diff = (secondDate.getTime() - firstDate.getTime()) / 86400000.0;
			System.out.println(Math.round(diff));
		} catch (ParseException e) {
			System.out.println("Wrong date format. Please enter dates in format day-month-year");
			main(args);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
