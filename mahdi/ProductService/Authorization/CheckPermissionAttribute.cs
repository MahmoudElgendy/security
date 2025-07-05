namespace productservice.Authorization
{
    [AttributeUsage(AttributeTargets.Method , AllowMultiple = true)]
    public class CheckPermissionAttribute : Attribute
    {
        public Permissions Permission { get; }

        public CheckPermissionAttribute(Permissions permission)
        {
            Permission = permission;
        }
    }
}
