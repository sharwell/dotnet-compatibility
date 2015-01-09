namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>virtual</c> modifier must not be removed from a publicly-accessible member.
    /// </summary>
    internal class VirtualMustNotBeRemovedFromMember : CompatibilityDescriptor
    {
        private const string Id = nameof(VirtualMustNotBeRemovedFromMember);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'virtual' modifier must not be removed from a member.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly VirtualMustNotBeRemovedFromMember Instance = new VirtualMustNotBeRemovedFromMember();

        private VirtualMustNotBeRemovedFromMember()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
