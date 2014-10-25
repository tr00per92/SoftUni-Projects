public class Appliance extends ElectonicsProduct {
    private static final int APPLIANCE_GUARANTEE = 6;

    public Appliance(String name, double price, double quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, APPLIANCE_GUARANTEE);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() < 50) {
            return super.getPrice() * 1.05;
        }

        return super.getPrice();
    }
}
