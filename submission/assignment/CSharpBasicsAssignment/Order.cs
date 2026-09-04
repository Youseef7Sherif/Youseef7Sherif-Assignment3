namespace CSharpBasicsAssignment;

public class Order
{
    public int OrderId;
    public string CustomerName;
    public int Quantity;
    public decimal UnitPrice;
    public decimal TotalPrice;
    public bool IsPaid;
    public double DiscountPercent;
    public string ShippingCity;
    public char Priority;
    public long ItemCode;

    public void CalculateTotal()
    {
        TotalPrice = Quantity * UnitPrice * (decimal)(1 - DiscountPercent / 100);
    }
    public void PrintSummary()
    {
        Console.WriteLine($"Order Summary: OrderId = {OrderId}, CustomerName = {CustomerName}, TotalPrice = {TotalPrice}, IsPaid = {IsPaid}");
    }

}

