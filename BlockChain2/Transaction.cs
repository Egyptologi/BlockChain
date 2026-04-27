namespace BlockChain2;

public class Transaction
{
    public string Id { get; set; }
    
    public string From { get; set; }
    public string To { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime Timestamp { get; set; }

    public Transaction(string from, string to, decimal amount)
    {
        From = from;
        To = to;
        Amount = amount;
        Timestamp = DateTime.UtcNow;
        Id = Guid.NewGuid().ToString();
    }

    public string ToRawString()
    {
        return $"{From}{To}{Amount}{Timestamp:O}";
    }

    public override string ToString()
    {
        return $"Transaction: Id: {Id}, From: {From}, To: {To}, Amount: {Amount}, Timestamp: {Timestamp}";
    }
}