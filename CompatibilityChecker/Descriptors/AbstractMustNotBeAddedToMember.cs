namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>abstract</c> modifier must not be added to a member of a publicly-accessible type.
    /// </summary>
    internal class AbstractMustNotBeAddedToMember : CompatibilityDescriptor
    {
        private const string Id = nameof(AbstractMustNotBeAddedToMember);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'abstract' modifier cannot be added to a member.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly AbstractMustNotBeAddedToMember Instance = new AbstractMustNotBeAddedToMember();

        private AbstractMustNotBeAddedToMember()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
