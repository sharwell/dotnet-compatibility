namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>abstract</c> modifier must not be removed from a publicly-accessible member.
    /// </summary>
    internal class AbstractMustNotBeRemovedFromMember : CompatibilityDescriptor
    {
        private const string Id = nameof(AbstractMustNotBeRemovedFromMember);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'abstract' modifier cannot be removed from a member.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly AbstractMustNotBeRemovedFromMember Instance = new AbstractMustNotBeRemovedFromMember();

        private AbstractMustNotBeRemovedFromMember()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
