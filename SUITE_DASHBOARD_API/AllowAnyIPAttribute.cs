namespace API_SERVICES
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AllowAnyIPAttribute: Attribute
    {
    }
}
