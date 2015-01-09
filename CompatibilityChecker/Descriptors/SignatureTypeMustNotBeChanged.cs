namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The type of a property, field, parameter, or return value cannot be changed.
    /// </summary>
    /// <remarks>
    /// <para>Changes to the type of a parameter may be reported as <see cref="MemberMustNotBeRemoved"/>.</para>
    /// </remarks>
    internal class SignatureTypeMustNotBeChanged : CompatibilityDescriptor
    {
        private const string Id = nameof(SignatureTypeMustNotBeChanged);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "A type appearing in a member signature cannot change.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly SignatureTypeMustNotBeChanged Instance = new SignatureTypeMustNotBeChanged();

        private SignatureTypeMustNotBeChanged()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
