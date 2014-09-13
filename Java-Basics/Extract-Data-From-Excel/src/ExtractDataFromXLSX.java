import java.io.FileInputStream;
import java.util.Locale;
import java.util.TreeMap;

import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class ExtractDataFromXLSX {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		try (FileInputStream input = new FileInputStream("Incomes-Report.xlsx")) {
			XSSFWorkbook wb = new XSSFWorkbook(input);
			XSSFSheet sheet = wb.getSheet("Incomes");
			TreeMap<String, Double> allOffices = new TreeMap<String, Double>();
			double totalIncome = 0;
			
			XSSFRow currentRow = sheet.getRow(1);
			while (currentRow != null) {
				XSSFCell officeCell = currentRow.getCell(0);
				String currentOffice = officeCell.getStringCellValue();
				XSSFCell incomeCell = currentRow.getCell(5);
				double currentIncome = incomeCell.getNumericCellValue();			
				totalIncome += currentIncome;
				if (allOffices.containsKey(currentOffice)) {
					currentIncome += allOffices.get(currentOffice);
				}
				allOffices.put(currentOffice, currentIncome);
				currentRow = sheet.getRow(1 + currentRow.getRowNum());
			}
			for (String office: allOffices.keySet()) {			
	            double income = allOffices.get(office);  
	            System.out.printf("%s -> %.2f", office, income);  
	            System.out.println();
			}
			System.out.println("Grand Total -> " + totalIncome);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
