public class _03_FullHouse {

	public static void main(String[] args) {
		String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		char[] suits = {'♣', '♦', '♥', '♠'};
		int count = 0;
		for (int i1 = 0; i1 < faces.length; i1++){
			for (int i2 = 0; i2 < faces.length; i2++){
				if (i1 == i2){
					continue;
				}
				for (int i3 = 0; i3 < 4; i3++) {
					for (int i4 = i3 + 1; i4 < 4; i4++) {
						for (int i5 = i4 + 1; i5 < 4; i5++) {
							for (int i6 = 0; i6 < 4; i6++) {
								for (int i7 = i6 + 1; i7 < 4; i7++) {					
									System.out.print("(" + faces[i1] + suits[i3] + " ");
									System.out.print(faces[i1] + suits[i4] + " ");
									System.out.print(faces[i1] + suits[i5] + " ");
									System.out.print(faces[i2] + suits[i6] + " ");
									System.out.print(faces[i2] + suits[i7] + ") ... ");
									count++;
								}
							}
						}
					}
				}
			}
		}
		System.out.println();
		System.out.println(count + " full houses");
	}
}