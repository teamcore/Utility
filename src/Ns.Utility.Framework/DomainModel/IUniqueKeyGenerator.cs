namespace Ns.Utility.Framework.DomainModel
{
    public interface IUniqueKeyGenerator
    {
        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string GenerateKey(string key);
    }
}
