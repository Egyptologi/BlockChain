// See https://aka.ms/new-console-template for more information

using BlockChain2;

var displayServise = new DisplayService();
var blockChainService = new BlockChainServise();

for (int i = 0; i < 5; i++)
{
    blockChainService.AddBlock("A", "A->C");
    blockChainService.AddBlock("B", "B->A");
    blockChainService.AddBlock("C", "C->B");
    Console.WriteLine("Difficulty:  " + blockChainService.Difficulty);
    displayServise.DisplayBlockChain(blockChainService.Chain);
}

displayServise.ShowHistotyDifficulty(blockChainService.Chain);