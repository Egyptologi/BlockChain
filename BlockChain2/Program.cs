// See https://aka.ms/new-console-template for more information

using BlockChain2;

var displayServise = new DisplayService();
var blockChainService = new BlockChainServise();

var walletA = new Wallet(new CryptoServise());
var walletB = new Wallet(new CryptoServise());


var transaction = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 10, walletA.PrivateKey);
blockChainService.AddBlock(new List<Transaction>{transaction});

displayServise.DisplayBlockChain(blockChainService.Chain);