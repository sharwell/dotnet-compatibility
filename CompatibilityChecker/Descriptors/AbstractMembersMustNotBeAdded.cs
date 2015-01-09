namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// Abstract members cannot be added to a publicly-accessible type, unless that type does not have any
    /// publicly-accessible constructors, or if the type is <c>sealed</c> (the latter case is not allowed in C#
    /// code, but may appear in assemblies created by another compiler).
    /// </summary>
    internal class AbstractMembersMustNotBeAdded : CompatibilityDescriptor
    {
        private const string Id = nameof(AbstractMembersMustNotBeAdded);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "Abstract members cannot be added to a type.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly AbstractMembersMustNotBeAdded Instance = new AbstractMembersMustNotBeAdded();

        private AbstractMembersMustNotBeAdded()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
