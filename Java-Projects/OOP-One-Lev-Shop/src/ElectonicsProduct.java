public abstract class ElectonicsProduct extends Product {
    private int guaranteeInMonths;

    protected ElectonicsProduct(String name, double price, double quantity,
                                AgeRestriction ageRestriction, int guaranteeInMonths) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteeInMonths(guaranteeInMonths);
    }

    public int getGuaranteeInMonths() {
        return this.guaranteeInMonths;
    }

    public void setGuaranteeInMonths(int guaranteeInMonths) {
        if (guaranteeInMonths < 0) {
            throw new IllegalArgumentException("The guarantee cannot be a negative number.");
        }

        this.guaranteeInMonths = guaranteeInMonths;
    }
}
