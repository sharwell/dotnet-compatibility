namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The exposed visibility of a <c>protected</c> member must not be reduced, unless the declaring type does not have
    /// any publicly-accessible constructors or the type is <c>sealed</c>.
    /// </summary>
    internal class ProtectedVisibilityMustNotBeReduced : CompatibilityDescriptor
    {
        private const string Id = nameof(ProtectedVisibilityMustNotBeReduced);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The exposed visibility of a protected member cannot be reduced.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly ProtectedVisibilityMustNotBeReduced Instance = new ProtectedVisibilityMustNotBeReduced();

        private ProtectedVisibilityMustNotBeReduced()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
