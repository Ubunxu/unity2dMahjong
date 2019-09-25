using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace util.net
{
    /// <summary>
    /// 协议加密解密
    /// </summary>
    public class EncryptDecrypt
    {
        public static string defaultKey = "New=R8k543b24jv9Uye7QgQ=qw";
        public static string EncryptDecryptKey = "New=R8k543b24jv9Uye7QgQ=qw";

        /// <summary>
        /// 更新加密钥匙
        /// </summary>
        /// <param name="sCode"></param>
        public static void updateHashCode(string sCode)
        {
            EncryptDecryptKey = sCode;
            //debug.log("新公钥匙: " + sCode);
        }
        public static string EncryptDecryptKeyValue
        {
            get { return defaultKey; }
        }
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string EncryptString(string ConvertString, string key=null)
        {
            string str = Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(ConvertString), key));
            //由于网页传递参数时，会将加号编码成空格，但是在解码时却不会解码空格
            //str = str.Replace("+", "% 2B");
            return str;
        }

        /// <summary>
        /// MD5解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecryptString(string base64Str, string key=null)
        {
            byte[] bs = Convert.FromBase64String(base64Str);
            return Encoding.UTF8.GetString(Decrypt(bs, key));
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="buffer">要加密的字节</param>
        /// <returns></returns>
        public static byte[] Encrypt(ByteBuffer buffer, string key=null)
        {
            byte[] EncryptByte = buffer.getBufferAvailable();// buffer.getBuffer();
            return Encrypt(EncryptByte, key);
        }
        public static byte[] Encrypt(byte[] EncryptByte, string key=null)
        {
            key = key == null ? EncryptDecryptKey : key;
            //EncryptDecryptKey = key == "0" ? EncryptDecryptKey : key; 
            if (EncryptByte.Length == 0) { throw (new Exception("明文不得为空")); }
            if (string.IsNullOrEmpty(key)) { throw (new Exception("密钥不得为空")); }
            byte[] m_strEncrypt;
            byte[] m_btIV = Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ==");
            byte[] m_salt = Convert.FromBase64String("gsf4jvkyhye5/d7k8OrLgM==");
            Rijndael m_AESProvider = Rijndael.Create();
            try
            {
                MemoryStream m_stream = new MemoryStream();
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, m_salt);
                ICryptoTransform transform = m_AESProvider.CreateEncryptor(pdb.GetBytes(32), m_btIV);
                CryptoStream m_csstream = new CryptoStream(m_stream, transform, CryptoStreamMode.Write);
                m_csstream.Write(EncryptByte, 0, EncryptByte.Length);
                m_csstream.FlushFinalBlock();
                m_strEncrypt = m_stream.ToArray();
                m_stream.Close(); m_stream.Dispose();
                m_csstream.Close(); m_csstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }
            return m_strEncrypt;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="buffer">要解密的字节</param>
        /// <returns></returns>
        public static byte[] Decrypt(ByteBuffer buffer, string key=null)
        {
            byte[] DecryptByte = buffer.getBufferAvailable();
            return Decrypt(DecryptByte, key);
        }
        public static byte[] Decrypt(byte[] DecryptByte, string key=null)
        {
            //byte[] DecryptByte = buffer.getBuffer();
            key = key == null ? EncryptDecryptKey : key;
            if (DecryptByte.Length == 0) { throw (new Exception("密文不得为空")); }
            if (string.IsNullOrEmpty(key)) { throw (new Exception("密钥不得为空")); }
            byte[] m_strDecrypt;
            byte[] m_btIV = Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ==");
            byte[] m_salt = Convert.FromBase64String("gsf4jvkyhye5/d7k8OrLgM==");
            Rijndael m_AESProvider = Rijndael.Create();
            try
            {
                MemoryStream m_stream = new MemoryStream();
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, m_salt);
                ICryptoTransform transform = m_AESProvider.CreateDecryptor(pdb.GetBytes(32), m_btIV);
                CryptoStream m_csstream = new CryptoStream(m_stream, transform, CryptoStreamMode.Write);
                m_csstream.Write(DecryptByte, 0, DecryptByte.Length);
                m_csstream.FlushFinalBlock();
                m_strDecrypt = m_stream.ToArray();
                m_stream.Close(); m_stream.Dispose();
                m_csstream.Close(); m_csstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }
            return m_strDecrypt;
        }
    }
}
