namespace BlockChain2;

public class Block
{
    
    public int Index { get; set; }
    
    public DateTime TimeStamp { get; set; }
    
    public List<Transaction> Transactions { get; set; }
    
    public string Hash { get; set; }
    
    public string PreviousHash { get; set; }
    
    public long Nonce { get; set; } // for count of attempts 

    public double MiningDurationTime {get; set;}
    
    public int DifficultyAtMining {get; set;}

    public Block(int index, List<Transaction> data, DateTime timeStamp, string previousHash)
    {
        Index = index;
        TimeStamp = timeStamp;
        Transactions = data;
        Hash = "";
        PreviousHash = previousHash;
        Nonce = 0;
        MiningDurationTime = 0;
        
    }
}