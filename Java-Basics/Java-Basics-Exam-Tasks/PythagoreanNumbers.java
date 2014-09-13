import java.util.Arrays;
import java.util.Scanner;

public class PythagoreanNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        boolean hasResult = false;
        int[] nums = new int[n];
        for (int i = 0; i < n; i++) {
            nums[i] = sc.nextInt();
        }
        Arrays.sort(nums);
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                for (int k = j; k < n; k++) {
                    if (nums[i]*nums[i] + nums[j]*nums[j] == nums[k]*nums[k]) {
                        System.out.printf("%d*%d + %d*%d = %d*%d", nums[i], nums[i],
                                nums[j], nums[j], nums[k], nums[k]);
                        System.out.println();
                        hasResult = true;
                    }
                }
            }
        }
        if (!hasResult) {
            System.out.println("No");
        }
    }
}
