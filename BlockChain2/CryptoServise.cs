using System.Security.Cryptography;
using System.Text;

namespace BlockChain2;

public class CryptoServise
{
    public (string publickey, string privatekey) GenerateKeyPair()
    {
        using (var rsa = RSA.Create())
        {
            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            return (publicKey, privateKey);
        }
    }

    public byte[] SignTransaction(string data, string privatekey)
    {
        using (var rsa = RSA.Create())
        {
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privatekey), out _);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            return rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }

    public bool VerifyTransaction(string data, byte[] signature, string publickey)
    {
        using (var rsa = RSA.Create())
        {
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publickey), out _);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            return rsa.VerifyData(dataBytes, signature, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
        }
    }
}