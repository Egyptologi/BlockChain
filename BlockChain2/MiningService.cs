using System.Runtime.InteropServices.JavaScript;

namespace BlockChain2;

public class MiningService
{
    private readonly HashingService _hashingService;

    public MiningService(HashingService hashingService)
    {
        _hashingService = hashingService;
    }

    public void MineBlock(Block block, int difficulty)
    {
        var target = new string('0', difficulty);
        var start = System.Diagnostics.Stopwatch.StartNew();
        while (true)
        {
            block.Nonce++;
            block.Hash = _hashingService.ComputeHash(block);

            if (block.Hash.StartsWith(target))
            {
                Console.WriteLine($"Block mined: {block.Hash} with nonce {block.Nonce}");
                start.Stop();
                block.MiningDurationTime = start.Elapsed.TotalSeconds;
                block.DifficultyAtMining = difficulty;
                return;
            }
        }
    }
}

/*
public class MiningService
{
    private readonly HashingService _hashingService;

    public MiningService(HashingService hashingService)
    {
        _hashingService = hashingService;
    }

    public void MineBlock(Block block, string target)
    {
        bool found = false;

        Parallel.For(0, Environment.ProcessorCount, (core, state) =>
        {
            int nonce = core;

            while (!found)
            {
                block.Nonce = nonce;

                string hash = _hashingService.ComputeHash(block);

                if (hash.StartsWith(target))
                {
                    found = true;
                    block.Hash = hash;
                    block.Nonce = nonce;

                    Console.WriteLine($"\nBlock mined: {hash}");
                    Console.WriteLine($"Nonce: {nonce}");

                    state.Stop();
                    return;
                }

                nonce += Environment.ProcessorCount;
            }
        });
    }
}*/