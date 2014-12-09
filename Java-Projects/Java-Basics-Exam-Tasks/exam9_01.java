import java.util.Scanner;

public class exam9_01 {
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int[] box1 = new int[3];
		int[] box2 = new int[3];
		for (int i = 0; i < box1.length; i++) {
			box1[i] = input.nextInt(); 
		}
		for (int i = 0; i < box2.length; i++) {
			box2[i] = input.nextInt();
		}
		CheckBoxes(box1[0], box1[1], box1[2], box2[0], box2[1], box2[2]);
		CheckBoxes(box1[0], box1[1], box1[2], box2[0], box2[2], box2[1]);
		CheckBoxes(box1[0], box1[1], box1[2], box2[1], box2[0], box2[2]);
		CheckBoxes(box1[0], box1[1], box1[2], box2[1], box2[2], box2[0]);
		CheckBoxes(box1[0], box1[1], box1[2], box2[2], box2[1], box2[0]);
		CheckBoxes(box1[0], box1[1], box1[2], box2[2], box2[0], box2[1]);		
		CheckBoxes(box2[0], box2[1], box2[2], box1[0], box1[1], box1[2]);
		CheckBoxes(box2[0], box2[1], box2[2], box1[0], box1[2], box1[1]);
		CheckBoxes(box2[0], box2[1], box2[2], box1[1], box1[0], box1[2]);
		CheckBoxes(box2[0], box2[1], box2[2], box1[1], box1[2], box1[0]);
		CheckBoxes(box2[0], box2[1], box2[2], box1[2], box1[1], box1[0]);
		CheckBoxes(box2[0], box2[1], box2[2], box1[2], box1[0], box1[1]);		
	}
	static void CheckBoxes (int firstWidth, int firstHeight, int firstDepth,
	        				int secondWidth, int secondHeight, int secondDepth) {
	        if (firstWidth < secondWidth && firstHeight < secondHeight && firstDepth < secondDepth) {
	        	System.out.printf("(%d, %d, %d) < (%d, %d, %d)",
	                firstWidth, firstHeight, firstDepth, secondWidth, secondHeight, secondDepth);
	        	System.out.println();
	        }
	}
}