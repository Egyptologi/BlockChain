using System.ComponentModel.DataAnnotations;

namespace BlockChain2;

public class TransactionServise
{
    
    static private readonly CryptoServise cryptoServise;

    static TransactionServise()
    {
        cryptoServise = new CryptoServise();
    }

    public static Transaction CreateTransaction(string from, string to, decimal amount, string privatekey)
    {
        var tx = new Transaction(from, to, amount);
        SignTransaction(tx, privatekey);
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
        if (!cryptoServise.VerifyTransaction(transaction.ToRawString(), transaction.Signature, transaction.From)) { return (false, "Invalid transaction"); }
        
        return (true, null);
    }

    public static void SignTransaction(Transaction transaction, string privateKey)
    {
        var signature = cryptoServise.SignTransaction(transaction.ToString(),  privateKey);
        transaction.Signature = signature;
    }
}