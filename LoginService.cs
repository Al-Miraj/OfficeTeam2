public class LoginService : ILoginService
{
    private Account _loggedInUser = null;
    private bool _isLoggedIn = false;

    public async Task<bool> LogInAsync(Account account)
    {
        if (!DomainInputValidation.IsValidUsername(account.Username) || !DomainInputValidation.IsValidPassword(account.Password))
        {
            return false;
        }

        PlaceholderDB placeholderDB = new PlaceholderDB();

        if (placeholderDB.SearchAccount(account.Username, account.Password))
        {
            _loggedInUser = account;
            _isLoggedIn = true;
            return true;
        }

        return false;
    }

    public bool CheckSession()
    {
        return _isLoggedIn;
    }

    public Account GetLoggedInUser()
    {
        return _loggedInUser;
    }

    public void LogOut()
    {
        _loggedInUser = null!;
        _isLoggedIn = false;
    }
}