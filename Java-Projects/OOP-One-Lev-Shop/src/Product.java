import Interfaces.Buyable;

public abstract class Product implements Buyable {
    private String name;
    private double price;
    private double quantity;
    private AgeRestriction ageRestriction;

    protected Product(String name, double price, double quantity, AgeRestriction ageRestriction) {
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.setAgeRestriction(ageRestriction);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name == null || name.equals("")) {
            throw new IllegalArgumentException("The name cannot be empty");
        }

        this.name = name;
    }

    public double getPrice() {
        return this.price;
    }

    public void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException("The price must be a positive number");
        }

        this.price = price;
    }

    public double getQuantity() {
        return this.quantity;
    }

    public void setQuantity(double quantity) {
        if (quantity <= 0) {
            throw new IllegalArgumentException("The quantity must be a positive number");
        }

        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestriction() {
        return this.ageRestriction;
    }

    public void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestriction = ageRestriction;
    }
}
