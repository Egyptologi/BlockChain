namespace BlockChain2;

public class Wallet
{
    public string PrivateKey { get; set; }
    public string PublicKey { get; set; }

    public Wallet(CryptoServise cryptoService)
    {
        var keyPair = cryptoService.GenerateKeyPair();
        PrivateKey = keyPair.privatekey;
        PublicKey = keyPair.publickey;
    }
}