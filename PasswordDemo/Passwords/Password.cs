
using System.Security.Cryptography;
using System.Text;

namespace Passwords
{

    /// <summary>
    /// String类型的加密类
    /// </summary>
    public static class Password
    {
        ///<summary>
        ///加密
        ///</summary>
        /// <param name="content">
        /// 未加密内容
        /// </param>
        /// <param name="secretKey">
        /// 密钥：只支持4位字符
        /// </param>
        /// <returns>
        /// 加密内容
        /// </returns>
        /// <exception>
        /// catch:return 原内容
        /// </exception>
        public static string Encrypt(string content, string secretKey)
        {
            try
            {
                byte[] key = Encoding.Unicode.GetBytes(secretKey);//密钥
                byte[] data = Encoding.Unicode.GetBytes(content);//待加密字符串

                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();//内存流对象

                //用内存流实例化加密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流

                return System.Convert.ToBase64String(temp);//返回加密后的字符串
            }
            catch
            {
                return content;
            }
        }
        ///<summary>
        ///解密
        ///</summary>
        /// <param name="content">
        /// 已加密内容
        /// </param>
        /// <param name="secretKey">
        /// 密钥：只支持4位字符
        /// </param>
        /// <returns>
        /// 解密内容
        /// </returns>
        /// <exception>
        /// catch:return 原内容
        /// </exception>
        public static string Decrypt(string content, string secretKey)
        {
            try
            {
                byte[] key = Encoding.Unicode.GetBytes(secretKey);//密钥
                byte[] data = System.Convert.FromBase64String(content);//待解密字符串

                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();//内存流对象

                //用内存流实例化解密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流

                return Encoding.Unicode.GetString(temp);//返回解密后的字符串
            }
            catch
            {
                return content;
            }
        }
    }
}
