using System;

namespace VyesBase.Utils.AutoBind
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutoBindAttribute : Attribute
    {
        public readonly BindScope Scope;
        public readonly string Path;

        public AutoBindAttribute()
        {
            Scope = BindScope.Self;
            Path = string.Empty;
        }

        public AutoBindAttribute(BindScope scope)
        {
            Scope = scope;
            Path = string.Empty;
        }

        public AutoBindAttribute(string path)
        {
            Scope = BindScope.Children; // Mặc định tìm trong con nếu truyền path
            Path = path;
        }

        public AutoBindAttribute(BindScope scope, string path)
        {
            Scope = scope;
            Path = path;
        }
    }
}