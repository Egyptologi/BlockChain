namespace BlockChain2;

public class Block
{
    
    public int Index { get; set; }
    
    public DateTime TimeStamp { get; set; }
    
    public string Data { get; set; }
    
    public string Hash { get; set; }
    
    public string PreviousHash { get; set; }
    
    public string Author { get; set; }
    
    public long Nonce { get; set; } // for count of attempts 

    public double MiningDurationTime {get; set;}
    
    public int DifficultyAtMining {get; set;}

    public Block(int index, string author, DateTime timeStamp, string data, string previousHash)
    {
        Index = index;
        Author = author;
        TimeStamp = timeStamp;
        Data = data;
        Hash = "";
        PreviousHash = previousHash;
        Nonce = 0;
        MiningDurationTime = 0;
        
    }
    
    public Block() {}
}