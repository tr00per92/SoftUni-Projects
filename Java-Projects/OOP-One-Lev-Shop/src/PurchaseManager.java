public final class PurchaseManager {
    public static void ProcessPurchase(Customer customer, Product product) {
        if (product.getQuantity() <= 0) {
            throw new IllegalStateException("The product is out of stock");
        }

        if (product instanceof FoodProduct && ((FoodProduct) product).getDaysUntilExpiration() < 0) {
            throw new IllegalStateException("The product is expired");
        }

        if (customer.getBalance() < product.getPrice()) {
            throw new IllegalStateException("The customer is out of money");
        }

        if ((product.getAgeRestriction() == AgeRestriction.Adult && customer.getAge() < 18) ||
                product.getAgeRestriction() == AgeRestriction.Teenager && customer.getAge() < 13) {
            throw new IllegalStateException("The customer is too young");
        }

        customer.setBalance(customer.getBalance() - (product.getPrice()));
        product.setQuantity(product.getQuantity() - 1);
    }
}
