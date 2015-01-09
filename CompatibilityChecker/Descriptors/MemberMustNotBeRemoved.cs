namespace CompatibilityChecker.Descriptors
{
    using System.Reflection;

    /// <summary>
    /// Publicly accessible members cannot be removed from a release.
    /// </summary>
    /// <remarks>
    /// <para>Many types of changes have the effect of removing a member from the compiled output. These include but
    /// are not limited to the following.</para>
    /// <list type="bullet">
    /// <item>Renaming a member</item>
    /// <item>Removing a getter or setter from a property</item>
    /// <item>Adding a constructor to a type that did not previously have a user-defined constructor, unless the
    /// default constructor is also added (C# automatically includes a default constructor when no constructor is
    /// specified)</item>
    /// <item>Removing an enum member</item>
    /// <item>Adding, removing, reordering, or changing the type of a parameter to a method</item>
    /// </list>
    /// </remarks>
    internal class MemberMustNotBeRemoved : CompatibilityDescriptor
    {
        private const string Id = nameof(MemberMustNotBeRemoved);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "{0} '{1}' cannot be removed.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly MemberMustNotBeRemoved Instance = new MemberMustNotBeRemoved();

        private MemberMustNotBeRemoved()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage(MemberTypes memberType, string metadataName)
        {
            return new Message(Instance, memberType, metadataName);
        }
    }
}
