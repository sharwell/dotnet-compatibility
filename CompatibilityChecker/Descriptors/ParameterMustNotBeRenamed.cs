namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The name of a parameter of a publicly-accessible method cannot change (case-sensitive).
    /// </summary>
    internal class ParameterMustNotBeRenamed : CompatibilityDescriptor
    {
        private const string Id = nameof(ParameterMustNotBeRenamed);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The name of a method parameter cannot change.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly ParameterMustNotBeRenamed Instance = new ParameterMustNotBeRenamed();

        private ParameterMustNotBeRenamed()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
