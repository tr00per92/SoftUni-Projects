public class Product implements Comparable<Product> {
	private String name;
	private double price;
	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public double getPrice() {
		return price;
	}
	public void setPrice(double price) {
		this.price = price;
	}
	@Override
	public int compareTo(Product prod) {
        if (this.price > prod.getPrice()) {
        	return 1;
        }
        else if (this.price < prod.getPrice()) {
        	return -1;
        }
        return 0;
	}
}