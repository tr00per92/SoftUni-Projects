public class Computer extends ElectonicsProduct {
    private static final int COMPUTER_GUARANTEE = 24;

    public Computer(String name, double price, double quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, COMPUTER_GUARANTEE);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() > 1000) {
            return super.getPrice() * 0.95;
        }

        return super.getPrice();
    }
}
