import java.util.Date;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Test {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("Blaze it", 6.90, 1400, AgeRestriction.Adult, new Date());
        Customer pecata = new Customer("Pecata", 17, 30.00);
        try {
            PurchaseManager.ProcessPurchase(pecata, cigars);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        Customer gopeto = new Customer("Gopeto", 18, 0.44);
        try {
            PurchaseManager.ProcessPurchase(gopeto, cigars);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        ArrayList<Product> products = new ArrayList<>();
        products.add(cigars);
        products.add(new Computer("Lenovo", 1000, 500, AgeRestriction.None));
        products.add(new Computer("AdultOnly", 10000, 2, AgeRestriction.Adult));
        products.add(new FoodProduct("Choko", 5, 3400, AgeRestriction.Teenager, new Date()));
        products.add(new Appliance("Fridge", 1200, 100, AgeRestriction.Adult));

        Product expiresFirst = products
                .stream()
                .filter(p -> p instanceof FoodProduct)
                .sorted((p1, p2) -> Long.compare(
                        ((FoodProduct) p1).getDaysUntilExpiration(),
                        ((FoodProduct) p2).getDaysUntilExpiration()))
                .findFirst()
                .get();

        System.out.println("\n" + expiresFirst.getName() + "\n");

        List<Product> restrictedForAdultsByPrice = products
                .stream()
                .filter(p -> p.getAgeRestriction() == AgeRestriction.Adult)
                .sorted((p1, p2) -> Double.compare(
                        p1.getPrice(),
                        p2.getPrice()))
                .collect(Collectors.toList());

        for (Product product : restrictedForAdultsByPrice) {
            System.out.println(product.getName() + " -> Price: " + product.getPrice());
        }
    }
}
