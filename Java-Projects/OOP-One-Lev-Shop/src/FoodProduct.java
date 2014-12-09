import Interfaces.Expirable;

import java.util.Date;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class FoodProduct extends Product implements Expirable{
    private Date expirationDate;

    public FoodProduct(String name, double price, double quantity,
                       AgeRestriction ageRestriction, Date expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    @Override
    public double getPrice() {
        if (this.getDaysUntilExpiration() <= 15) {
            return super.getPrice() * 0.7;
        }

        return super.getPrice();
    }

    public long getDaysUntilExpiration() {
        long daysUntilExpiration = TimeUnit.DAYS.convert(
                this.expirationDate.getTime() - new Date().getTime(), TimeUnit.MILLISECONDS);
        return daysUntilExpiration;
    }

    public Date getExpirationDate() {
        return expirationDate;
    }

    public void setExpirationDate(Date expirationDate) {
        if(expirationDate.before(new Date())) {
            throw new IllegalArgumentException("The product is expired");
        }

        this.expirationDate = expirationDate;
    }
}
