// See https://aka.ms/new-console-template for more information

using BlockChain2;

var displayServise = new DisplayService();
var blockChainService = new BlockChainServise();

blockChainService.AddBlock(new List<Transaction>());
blockChainService.AddBlock(new List<Transaction> {TransactionServise.CreateTransaction("A", "B", 10.0M)});
blockChainService.AddBlock(new List<Transaction> {TransactionServise.CreateTransaction("B", "A", 20.0M)});
blockChainService.AddBlock(new List<Transaction> {TransactionServise.CreateTransaction("B", "C", 10.0M), TransactionServise.CreateTransaction("C", "B", 10.0M)});

displayServise.DisplayBlockChain(blockChainService.Chain);

var blockChainExplorer = new BlockChainExplorer(blockChainService.Chain);
Console.WriteLine($"Sum: {blockChainExplorer.GetTotalVolume()}");
Console.WriteLine($"Largest transaction: {blockChainExplorer.GetLargestTransaction().ToString()}");
foreach (var his in blockChainExplorer.GetAddressHistory("A"))
{
    Console.WriteLine($"Address: {his.ToString()}");
}