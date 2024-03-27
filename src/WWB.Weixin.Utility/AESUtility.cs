using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WWB.Weixin.Utility
{
    public class AESUtility
    {
        private const int AES_KEY_SIZE = 256;
        private const int AES_BLOCK_SIZE = 128;

        private static char ConvertToChar(int i)
        {
            byte ret = (byte)(i & 0xFF);
            return (char)ret;
        }

        private static byte[] KCS7Encoder(int len)
        {
            if (len <= 0) throw new ArgumentOutOfRangeException(nameof(len));

            const int BLOCK_SIZE = 32;

            int paddingLength = BLOCK_SIZE - len % BLOCK_SIZE;
            if (paddingLength == 0)
            {
                paddingLength = BLOCK_SIZE;
            }

            char paddingChar = ConvertToChar(paddingLength);
            string tmp = string.Empty;
            for (int index = 0; index < paddingLength; index++)
            {
                tmp += paddingChar;
            }

            return Encoding.UTF8.GetBytes(tmp);
        }

        private static string CreateRandCode(int len)
        {
            if (len <= 0) throw new ArgumentOutOfRangeException(nameof(len));

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            string[] source = "2,3,4,5,6,7,a,c,d,e,f,h,i,j,k,m,n,p,r,s,t,A,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,U,V,W,X,Y,Z".Split(',');
            string result = string.Empty;
            for (int i = 0; i < len; i++)
            {
                int randval = random.Next(0, source.Length - 1);
                result += source[randval];
            }

            return result;
        }

        private static byte[] Decode2(byte[] decryptedBytes)
        {
            if (decryptedBytes is null) throw new ArgumentNullException(nameof(decryptedBytes));

            int pad = decryptedBytes[decryptedBytes.Length - 1];
            if (pad < 1 || pad > 32)
            {
                pad = 0;
            }

            byte[] res = new byte[decryptedBytes.Length - pad];
            Array.Copy(decryptedBytes, 0, res, 0, decryptedBytes.Length - pad);
            return res;
        }

        public static byte[] AESDecrypt(byte[] keyBytes, byte[] ivBytes, byte[] cipherBytes)
        {
            if (keyBytes is null) throw new ArgumentNullException(nameof(keyBytes));
            if (ivBytes is null) throw new ArgumentNullException(nameof(ivBytes));
            if (cipherBytes is null) throw new ArgumentNullException(nameof(cipherBytes));

            using var aes = Aes.Create();
            aes.KeySize = AES_KEY_SIZE;
            aes.BlockSize = AES_BLOCK_SIZE;
            aes.Mode = CipherMode.CBC;
            //aes.Padding = PaddingMode.PKCS7;
            aes.Padding = PaddingMode.None;
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
            {
                byte[] msgBytes = new byte[cipherBytes.Length + 32 - cipherBytes.Length % 32];
                Array.Copy(cipherBytes, msgBytes, cipherBytes.Length);
                cs.Write(cipherBytes, 0, cipherBytes.Length);

                byte[] plainBytes = Decode2(ms.ToArray());
                return plainBytes;
            }
        }

        public static string AESEncrypt(byte[] keyBytes, byte[] ivBytes, byte[] plainBytes)
        {
            if (keyBytes is null) throw new ArgumentNullException(nameof(keyBytes));
            if (ivBytes is null) throw new ArgumentNullException(nameof(ivBytes));
            if (plainBytes is null) throw new ArgumentNullException(nameof(plainBytes));

            using var aes = Aes.Create();
            aes.KeySize = AES_KEY_SIZE;
            aes.BlockSize = AES_BLOCK_SIZE;
            //aes.Padding = PaddingMode.PKCS7;
            aes.Padding = PaddingMode.None;
            aes.Mode = CipherMode.CBC;
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            byte[] msgBytes = new byte[plainBytes.Length + 32 - plainBytes.Length % 32];
            Array.Copy(plainBytes, msgBytes, plainBytes.Length);
            byte[] padBytes = KCS7Encoder(plainBytes.Length);
            Array.Copy(padBytes, 0, msgBytes, plainBytes.Length, padBytes.Length);

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(msgBytes, 0, msgBytes.Length);
                byte[] chiperBytes = ms.ToArray();
                return Convert.ToBase64String(chiperBytes);
            }
        }

        /// <summary>
        /// AES 解密企业微信加密数据。
        /// </summary>
        /// <param name="cipherText">企业微信推送来的加密文本内容（即 `Encrypt` 字段的值）。</param>
        /// <param name="encodingAESKey">企业微信后台设置的 EncodingAESKey。</param>
        /// <param name="corpId">企业微信 CorpId 或第三方应用的 SuiteId。</param>
        /// <returns>解密后的文本内容。</returns>
        public static string AESDecrypt(string cipherText, string encodingAESKey, out string corpId)
        {
            if (cipherText is null) throw new ArgumentNullException(nameof(cipherText));
            if (encodingAESKey is null) throw new ArgumentNullException(nameof(encodingAESKey));

            byte[] chiperBytes = Convert.FromBase64String(cipherText);
            byte[] key = Convert.FromBase64String(encodingAESKey + "=");
            byte[] iv = new byte[16];
            Array.Copy(key, iv, 16);
            byte[] btmpMsg = AESDecrypt(cipherBytes: chiperBytes, ivBytes: iv, keyBytes: key);

            int len = BitConverter.ToInt32(btmpMsg, 16);
            len = IPAddress.NetworkToHostOrder(len);

            byte[] bMsg = new byte[len];
            byte[] bCorpId = new byte[btmpMsg.Length - 20 - len];
            Array.Copy(btmpMsg, 20, bMsg, 0, len);
            Array.Copy(btmpMsg, 20 + len, bCorpId, 0, btmpMsg.Length - 20 - len);

            corpId = Encoding.UTF8.GetString(bCorpId);
            return Encoding.UTF8.GetString(bMsg);
        }

        /// <summary>
        /// AES 加密企业微信敏感数据。
        /// </summary>
        /// <param name="plainText">返回给企业微信的原始文本内容。</param>
        /// <param name="encodingAESKey">企业微信后台设置的 EncodingAESKey。</param>
        /// <param name="corpId">企业微信 CorpId 或第三方应用的 SuiteId。</param>
        /// <returns>加密后的文本内容。</returns>
        public static string AESEncrypt(string plainText, string encodingAESKey, string corpId)
        {
            if (plainText is null) throw new ArgumentNullException(nameof(plainText));
            if (encodingAESKey is null) throw new ArgumentNullException(nameof(encodingAESKey));
            if (corpId is null) throw new ArgumentNullException(nameof(corpId));

            byte[] keyBytes = Convert.FromBase64String(encodingAESKey + "=");
            byte[] ivBytes = new byte[16];
            Array.Copy(keyBytes, ivBytes, 16);

            string randCode = CreateRandCode(16);
            byte[] bRand = Encoding.UTF8.GetBytes(randCode);
            byte[] bCorpId = Encoding.UTF8.GetBytes(corpId);
            byte[] bMsgTmp = Encoding.UTF8.GetBytes(plainText);
            byte[] bMsgLen = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(bMsgTmp.Length));
            byte[] bMsg = new byte[bRand.Length + bMsgLen.Length + bCorpId.Length + bMsgTmp.Length];

            Array.Copy(bRand, bMsg, bRand.Length);
            Array.Copy(bMsgLen, 0, bMsg, bRand.Length, bMsgLen.Length);
            Array.Copy(bMsgTmp, 0, bMsg, bRand.Length + bMsgLen.Length, bMsgTmp.Length);
            Array.Copy(bCorpId, 0, bMsg, bRand.Length + bMsgLen.Length + bMsgTmp.Length, bCorpId.Length);

            return AESEncrypt(keyBytes: keyBytes, ivBytes: ivBytes, plainBytes: bMsg);
        }
    }
}