namespace StyleLink.Constants;

public static class Values
{
    public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

    public const string PhoneNumberRegex = @"^\+?[0-9]\d{1,20}$";

    public const string BooleanTrueValue = "true";
}