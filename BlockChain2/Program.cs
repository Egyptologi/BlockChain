// See https://aka.ms/new-console-template for more information

using BlockChain2;

var displayServise = new DisplayService();
var blockChainService = new BlockChainServise();

var walletA = new Wallet(new CryptoServise());
var walletB = new Wallet(new CryptoServise());


var transaction = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 10, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction});
var transaction1 = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 20, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction1});
var transaction2 = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 30, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction2});
var transaction3 = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 40, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction3});
var transaction4 = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 50, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction4});
var transaction5 = TransactionServise.CreateTransaction(walletA.PublicKey, walletB.PublicKey, 60, walletA.PrivateKey);
blockChainService.MineBlock(walletA.PublicKey, new List<Transaction>{transaction5});

displayServise.DisplayBlockChain(blockChainService.Chain);