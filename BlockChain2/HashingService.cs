using System.Security.Cryptography;
using System.Text;

namespace BlockChain2;

public class HashingService
{
    public string ComputeHash(Block block)
    {
        string rawData = $"{block.Index}{block.Author}{block.TimeStamp}{block.Data}{block.PreviousHash}{block.Nonce}";
        return ComputeHash(rawData);
    }

    private string ComputeHash(string rawData)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(rawData);
        byte[] hashBytes = SHA256.HashData(inputBytes);
        
        return Convert.ToBase64String(hashBytes);
    }
    
    
}