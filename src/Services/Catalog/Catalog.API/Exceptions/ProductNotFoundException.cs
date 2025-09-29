namespace Catalog.API.Exceptions
{
    [Serializable]
    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string v) : base("Product not found")
        {
        }
    }
}