using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace TodoApp_Net8.Utility
{
    public static class Helper
    {
        /// <summary>
        /// パスワードを暗号化します。
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static string GeneratePasswordHash(string password, string salt)
        {

            // パスワードとソルトを結合してバイト配列に変換
            byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);

            // ハッシュ関数の繰り返し回数
            int iterations = 10000;

            // 初回のハッシュ計算を行います
            byte[] hash = combinedBytes;

            using (HashAlgorithm hashProvider = SHA256.Create())
            {
                for (int i = 0; i < iterations; i++)
                {
                    // バイト配列をハッシュ化してハッシュ値を計算
                    hash = hashProvider.ComputeHash(hash);
                }
            }

            // ハッシュ値を Base64 エンコードして文字列として返す
            return Convert.ToBase64String(hash);
        }
    }
}
