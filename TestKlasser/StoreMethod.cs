namespace Lab2_v2;

public class StoreMethod
{
    public static void AddToCart(int prodId)
    {

        if (Customer.Cart.Contains(DataSource.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in Customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                item.Qty++;
            }
        }
        else
        {
            Customer.Cart.AddRange(DataSource.Stock.FindAll(p => p.Id == prodId));
        }
    }
    public static void RemoveFromCart(int prodId)
    {
        if (Customer.Cart.Contains(DataSource.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in Customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                if (item.Qty > 0)
                {
                    item.Qty--;
                }
            }
        }
        else
        {
            Customer.Cart.AddRange(DataSource.Stock.FindAll(p => p.Id == prodId));
        }
    }

    public static void PrintCart()
    {
        double totalSum = 0;
        foreach (var p in Customer.Cart)
        {
            Console.WriteLine($"Produkt: {p.Name} | Pris: {p.Price} | Antal: {p.Qty} | Totalpris: {string.Format("{0:0.00}", p.Qty * p.Price)}");
            totalSum += p.Qty * p.Price;
        }

        Console.WriteLine($"\nPris totalt: {string.Format("{0:0.00}", totalSum)}");
    }
}