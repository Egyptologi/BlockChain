namespace BlockChain2;

public class BlockChainExplorer
{
    private List<Block> _chain;

    public BlockChainExplorer(List<Block> chain)
    {
        _chain = chain;
    }

    public decimal GetTotalVolume()
    {
        decimal total = 0;
        foreach (var block in _chain)
        {
            foreach (var tx in block.Transactions)
            {
                total += tx.Amount;
            }
        }
        
        return total;
    }

    public Transaction? GetLargestTransaction()
    {
        Transaction maxAmountTransaction = null;
        foreach (var block in _chain)
        {
            foreach (var tx in block.Transactions)
            {
                if (maxAmountTransaction == null) 
                {
                    maxAmountTransaction = tx;
                }

                if (tx.Amount > maxAmountTransaction.Amount)
                {
                    maxAmountTransaction = tx;
                }
            }
        }
        
        return maxAmountTransaction;
    }

    public List<Transaction> GetAddressHistory(string address)
    {
        List<Transaction> list = new List<Transaction>();
        foreach (var block in _chain)
        {
            foreach (var tx in block.Transactions)
            {
                if (tx.From.CompareTo(address) == 0 || tx.To.CompareTo(address) == 0)
                {
                    list.Add(tx);
                }
            }
        }
        
        return list;
    }
}