public class _04_FullHouseWithJokers {

	public static void main(String[] args) {
		String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		char[] suits = {'♣', '♦', '♥', '♠'};
		int count = 0;
		String[] fullHouse = new String[5];
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
									for (int i8 = 0; i8 < 32; i8++) {
										fullHouse[4] = faces[i1] + suits[i3];
										fullHouse[3] = faces[i1] + suits[i4];
										fullHouse[2] = faces[i1] + suits[i5];
										fullHouse[1] = faces[i2] + suits[i6];
										fullHouse[0] = faces[i2] + suits[i7];
										int temp = i8;
										for (int i9 = 0; i9 < 5; i9++) {
											if (temp % 2 == 1) {
											fullHouse[i9] = "*";
											temp >>= 2;
											}
										}
										count++;
										System.out.print("(" + fullHouse[0] + " ");
										System.out.print(fullHouse[1] + " ");
										System.out.print(fullHouse[2] + " ");
										System.out.print(fullHouse[3] + " ");
										System.out.print(fullHouse[4] + ") ... ");				
									}									
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