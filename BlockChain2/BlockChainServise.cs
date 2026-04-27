using System.Security.Cryptography;

namespace BlockChain2;

public class BlockChainServise
{
    public List<Block> Chain { get; set; }
    private HashingService _hashingService;
    private MiningService _miningService;
    
    public int Difficulty = 1;

    private readonly double _targetBlockTimeSeconds = 1;
    private readonly int _difficultyAdjustmentInterval = 1;
    
    
    public BlockChainServise()
    {
        _hashingService = new HashingService();
        _miningService = new MiningService(_hashingService);
        Chain = new List<Block>();
        AddGenesisBlock();
    }

    private void AddGenesisBlock()
    {
        Block block = new Block(0,new List<Transaction>(), DateTime.Parse("2024-06-01T00:00:00.000Z"), "0");
        block.Hash = _hashingService.ComputeHash(block);
        Chain.Add(block);
    }

    public void AddBlock(List<Transaction> data)
    {
        foreach (var tx in data)
        {
            var isValid = TransactionServise.ValidateTransaction(tx);
            if (!isValid.isValid)
            {
                Console.WriteLine($"Invalide transaction: {isValid.error}");
                return;
            }
        }
        var lastBlock = Chain.Last();
        var newBlock = new Block(lastBlock.Index, data, DateTime.UtcNow, lastBlock.PreviousHash);
        
        _miningService.MineBlock(newBlock, Difficulty);
        Chain.Add(newBlock);
        if (newBlock.Index % _difficultyAdjustmentInterval == 0)
        {
            AdjustDifficulty();
        }
    }

    private void AdjustDifficulty()
    {
        var recentBlock = Chain.Skip(Chain.Count - _difficultyAdjustmentInterval).Take(_difficultyAdjustmentInterval).ToList();
        var totalMiningTime = recentBlock.Sum(b => b.MiningDurationTime);
        var avarageMiningTime = totalMiningTime / _difficultyAdjustmentInterval;

        if (avarageMiningTime < _targetBlockTimeSeconds)
        {
            if (Difficulty >= 6)
            {
                return;
            }
            if (_targetBlockTimeSeconds / avarageMiningTime >= 5 && Difficulty < 5)
            {
                Difficulty += 2;
                Console.WriteLine("Incrementing difficulty + 2");
                return;
            }
            Difficulty++;
            Console.WriteLine("Incrementing difficulty");
        } else if (avarageMiningTime > _targetBlockTimeSeconds)
        {
            if (Difficulty <= 1)
            {
                Console.WriteLine("Nothing difficulty");
                return;
            }
            else
            {
                if (avarageMiningTime >= 5 * _targetBlockTimeSeconds && Difficulty > 2)
                {
                    Difficulty -= 2;
                    Console.WriteLine("Decrementing difficulty - 2");
                    return;
                }
                Difficulty--;
                Console.WriteLine("Decrementing difficulty");
            }
        }
    }

    public bool IsValid()
    {
        for (int i = 1; i < Chain.Count; i++)
        {
            var currentBlock = Chain[i];
            var prevBlock =  Chain[i - 1];
            if (currentBlock.Hash != _hashingService.ComputeHash(currentBlock))
            {
                return false;
            }

            if (currentBlock.PreviousHash != prevBlock.Hash)
            {
                return false;
            }
            
            if (!currentBlock.Hash.StartsWith(new String('0', currentBlock.DifficultyAtMining)))
            {
                return false;
            }
        }
        return true;
    }
}