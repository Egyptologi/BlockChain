using System.ComponentModel.DataAnnotations;

namespace BlockChain2;

public class TransactionServise
{
    public TransactionServise()
    {}

    public static Transaction CreateTransaction(string from, string to, decimal amount)
    {
        var tx = new Transaction(from, to, amount);
        var valid = ValidateTransaction(tx);
        if (!valid.isValid)
        {
            throw new ValidationException(valid.error);
        }
        return tx;
    }

    public static (bool isValid, string error) ValidateTransaction(Transaction transaction)
    {
        if (transaction == null)
        {
            return (false, "Transaction is null");
        } if (string.IsNullOrEmpty(transaction.From)) {return (false, "Sender address is empty");}
        if (string.IsNullOrEmpty(transaction.To)) {return (false, "Receiver address is empty");}
        if (transaction.Amount <= 0) {return (false, "Amount is negative or zero");}
        
        return (true, null);
    }
}