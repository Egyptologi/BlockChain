using System.Security.Cryptography;
using System.Text;

namespace BlockChain2;

public class HashingService
{
    public string ComputeHash(Block block)
    {
        var transactionsData = string.Concat(block.Transactions.Select(tx => tx.ToRawString()).ToArray());
        string rawData = $"{block.Index}{block.TimeStamp}{transactionsData}{block.PreviousHash}{block.Nonce}";
        return ComputeHash(rawData);
    }

    private string ComputeHash(string rawData)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(rawData);
        byte[] hashBytes = SHA256.HashData(inputBytes);
        
        return Convert.ToHexString(hashBytes);
    }
    
    
}