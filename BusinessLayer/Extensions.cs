
namespace BusinessLayer
{
    public static class Extensions
    {
        public static bool IsNull(this object @object)
        {
            return @object == null;
        }
    }
}
