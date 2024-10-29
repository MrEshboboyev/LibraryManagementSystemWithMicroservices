namespace LibraryMS.Services.Membership.Application.Common.Utility;

public static class SD
{
    // Membership types
    public const string MembershipTypeTrial = "Trial";
    public const string MembershipTypeBasic = "Basic";
    public const string MembershipTypePremium = "Premium";

    // default expiration days
    public const int expirationDays = 30;

    // Max Books Allowed 
    public const int maxBooksAllowedForTrial = 10;
    public const int maxBooksAllowedForBasic = 100;
    public const int maxBooksAllowedForPremium = int.MaxValue;

    // Membership Fee
    public const int membershipFeeForTrial = 0;
    public const int membershipFeeForBasic = 10;
    public const int membershipFeeForPremium = 100;
}
