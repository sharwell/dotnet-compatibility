namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The exposed visibility of a publicly-accessible type must not be reduced.
    /// </summary>
    /// <remarks>
    /// <para>This diagnostic is only reported for nested types. Top-level types which reduce visibility are reported as
    /// <see cref="TypeMustNotBeRemoved"/>.</para>
    /// </remarks>
    internal class TypeVisibilityMustNotBeReduced : CompatibilityDescriptor
    {
        private const string Id = nameof(TypeVisibilityMustNotBeReduced);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The exposed visibility of a type must not be reduced.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly TypeVisibilityMustNotBeReduced Instance = new TypeVisibilityMustNotBeReduced();

        private TypeVisibilityMustNotBeReduced()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
