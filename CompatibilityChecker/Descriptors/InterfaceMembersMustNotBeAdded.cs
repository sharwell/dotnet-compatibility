namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// New members cannot be added to a publicly-accessible interface.
    /// </summary>
    internal class InterfaceMembersMustNotBeAdded : CompatibilityDescriptor
    {
        private const string Id = nameof(InterfaceMembersMustNotBeAdded);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "New members cannot be added to an interface.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly InterfaceMembersMustNotBeAdded Instance = new InterfaceMembersMustNotBeAdded();

        private InterfaceMembersMustNotBeAdded()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
