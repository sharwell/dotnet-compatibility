namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// An interface implementation must not be removed from a publicly-accessible type.
    /// </summary>
    /// <remarks>
    /// <para>It is not an error to remove an interface implementation from a type when that interface is also inherited
    /// from a base type, or if the implementation is <em>moved</em> to a base type.</para>
    /// </remarks>
    internal class InterfaceImplementationMustNotBeRemoved : CompatibilityDescriptor
    {
        private const string Id = nameof(InterfaceImplementationMustNotBeRemoved);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "An interface implementation cannot be removed from a type.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly InterfaceImplementationMustNotBeRemoved Instance = new InterfaceImplementationMustNotBeRemoved();

        private InterfaceImplementationMustNotBeRemoved()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
