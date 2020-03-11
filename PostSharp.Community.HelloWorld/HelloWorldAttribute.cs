using PostSharp.Extensibility;

namespace PostSharp.Community.DeepSerializable
{
    /// <summary>
    /// The target classes, and all classes that those classes reference, are marked as [Serializable] at build time.
    /// <para>
    /// Specifically, the following types will be marked as serializable: The annotated type, the types of its fields
    /// recursively, its base type recursively. If any of those types is a generic signature, then all types present in
    /// those generic signatures are marked as serializable recursively.
    /// </para>
    /// <para>
    /// Types that are in a different assembly cannot be modified this way so remain as they are.
    /// </para>
    /// </summary>
    [MulticastAttributeUsage(MulticastTargets.Method)]
    [RequirePostSharp("PostSharp.Community.HelloWorld.Weaver", "HelloWorldTask")]
    public class HelloWorldAttribute : MulticastAttribute
    { 
        /// <summary>
        /// The target classes, and all classes that those classes reference, are marked as [Serializable] at build time.
        /// <para>
        /// Specifically, the following types will be marked as serializable: The annotated type, the types of its fields
        /// recursively, its base type recursively. If any of those types is a generic signature, then all types present in
        /// those generic signatures are marked as serializable recursively.
        /// </para>
        /// <para>
        /// Types that are in a different assembly cannot be modified this way so remain as they are.
        /// </para>
        /// </summary>
        public HelloWorldAttribute()
        {
        }
    }
}