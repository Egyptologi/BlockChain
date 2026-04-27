namespace BlockChain2;

public class DisplayService
{
    public void DisplayBlockChain(List<Block> blocks)
    {
        foreach (var block in blocks)
        {
            Console.WriteLine($"Index: {block.Index}");
            Console.WriteLine($"Hash: {block.Hash}");
            Console.WriteLine($"Previous Hash: {block.PreviousHash}");
            foreach (var transaction in block.Transactions)
            {
                Console.WriteLine($"Transaction: {transaction.ToString()}");
            }
            Console.WriteLine($"TimeStamp: {block.TimeStamp}");
            Console.WriteLine($"Difficulty at mining: {block.DifficultyAtMining}");
            Console.WriteLine(new String('-', 50));
        }
    }

    public void ShowHistotyDifficulty(List<Block> blocks)
    {
        foreach (var block in blocks)
        {
            Console.WriteLine($"Index: {block.Index}, Difficulty at mining: {block.DifficultyAtMining}, Duration: {block.MiningDurationTime}");
            Console.WriteLine(new String('-', 50));
        }
    }
}